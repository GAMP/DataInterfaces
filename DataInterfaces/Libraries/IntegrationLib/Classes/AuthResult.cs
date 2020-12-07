using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Authentication result.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class AuthResult : IAuthResult, ISerializable
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Result.</param>
        public AuthResult(LoginResult result) : this(result, null)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="identity">Identity.</param>
        public AuthResult(LoginResult result, IUserIdentity identity) : this(result, identity, UserInfoTypes.None)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="identity">Identity.</param>
        /// <param name="requiredInfo">Required user info flags.</param>
        public AuthResult(LoginResult result, IUserIdentity identity, UserInfoTypes requiredInfo)
        {
            Identity = identity;
            Result = result;
            RequiredInfo = requiredInfo;
        }

        #endregion

        #region FIELDS
        private Dictionary<string, object> custom;
        [NonSerialized()]
        private IUserIdentity idenity;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// User identity.
        /// </summary>
        [DataMember()]
        public IUserIdentity Identity
        {
            get { return idenity; }
            set { idenity = value; }
        }

        /// <summary>
        /// Login result.
        /// </summary>
        [DataMember()]
        public LoginResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user info required after authentication.
        /// </summary>
        [DataMember()]
        public UserInfoTypes RequiredInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Custom fields dictionary.
        /// <remarks>This can used to provide custom data to authenticated party.</remarks>
        /// </summary>
        [DataMember()]
        public Dictionary<string, object> Custom
        {
            get
            {
                if (custom == null)
                    custom = new Dictionary<string, object>();
                return custom;
            }
            protected set { custom = value; }
        }

        #endregion

        #region ISerializable

        public AuthResult(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount < 3)
                return;

            //get base members
            Result = (LoginResult)info.GetValue(nameof(Result), typeof(LoginResult));
            RequiredInfo = (UserInfoTypes)info.GetValue(nameof(RequiredInfo), typeof(UserInfoTypes));
            Custom = (Dictionary<string, object>)info.GetValue(nameof(Custom), typeof(Dictionary<string, object>));

            if (info.MemberCount < 5)
                return;

            //check if result is sucessfull
            //if not we dont need to read any idenity properties to the serialization context
            if (Result != LoginResult.Sucess)
                return;

            var name = info.GetString(nameof(Identity.Name));
            var userId = info.GetInt32(nameof(Identity.UserId));
            var authenticationType = info.GetString(nameof(Identity.AuthenticationType));
            var role = (UserRoles)info.GetValue(nameof(Identity.Role), typeof(UserRoles));

            //get claims collection
            var claims = (IEnumerable<SerializableClaim>)info.GetValue(nameof(Identity.Claims), typeof(IEnumerable<SerializableClaim>));

            //create claim list
            var userClaims = claims.Select(cl => new System.Security.Claims.Claim(cl.Type, cl.Value)).ToList();

            Identity = new ClaimsUserIdentity(name, userId, role, userClaims);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add base members
            info.AddValue(nameof(Result), Result);
            info.AddValue(nameof(RequiredInfo), RequiredInfo);
            info.AddValue(nameof(Custom), Custom);

            //check if result is sucessfull
            //if not we dont need to add any idenity properties to the serialization context
            if (Result != LoginResult.Sucess || Identity == null)
                return;

            info.AddValue(nameof(Identity.Name), Identity.Name);
            info.AddValue(nameof(Identity.UserId), Identity.UserId);
            info.AddValue(nameof(Identity.AuthenticationType), Identity.AuthenticationType);
            info.AddValue(nameof(Identity.Role), Identity.Role);
            info.AddValue(nameof(Identity.Claims), Identity.Claims.Select(e => new SerializableClaim(e.Type, e.Value)).ToList());
        }

        #endregion

        #region SerializableClaim
        [Serializable()]
        public class SerializableClaim
        {
            #region CONSTRUCTOR

            public SerializableClaim(string type, string value)
            {
                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentNullException(nameof(type));

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));

                Type = type;
                Value = value;
            }
            
            #endregion

            #region FIELDS

            string claimType;
            string claimValue;

            #endregion

            #region PROPERTIES

            public string Type
            {
                get { return claimValue; }
                protected set { claimValue = value; }
            }

            public string Value
            {
                get { return claimType; }
                protected set { claimType = value; }
            }

            #endregion
        }
        #endregion
    }
}
