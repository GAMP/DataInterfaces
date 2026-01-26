using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Authentication result.
    /// </summary>
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
        public AuthResult(LoginResult result, IUserIdentity identity) : this(result, identity, Gizmo.Web.Api.Models.UserInfoTypes.None)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="identity">Identity.</param>
        /// <param name="requiredInfo">Required user info flags.</param>
        public AuthResult(LoginResult result, IUserIdentity identity, Gizmo.Web.Api.Models.UserInfoTypes requiredInfo)
        {
            Identity = identity;
            Result = result;
            RequiredInfo = requiredInfo;
        }

        #endregion

        #region FIELDS
        private Dictionary<string, object> _custom;
        [NonSerialized()]
        private IUserIdentity _identity;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// User identity.
        /// </summary>
        [DataMember()]
        public IUserIdentity Identity
        {
            get { return _identity; }
            set { _identity = value; }
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
        public Gizmo.Web.Api.Models.UserInfoTypes RequiredInfo
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
                if (_custom == null)
                    _custom = new Dictionary<string, object>();
                return _custom;
            }
            protected set { _custom = value; }
        }

        #endregion

        #region ISerializable

        public AuthResult(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount < 3)
                return;

            //get base members
            Result = (LoginResult)info.GetValue(nameof(Result), typeof(LoginResult));
            RequiredInfo = (Gizmo.Web.Api.Models.UserInfoTypes)info.GetValue(nameof(RequiredInfo), typeof(Gizmo.Web.Api.Models.UserInfoTypes));
            Custom = (Dictionary<string, object>)info.GetValue(nameof(Custom), typeof(Dictionary<string, object>));

            if (info.MemberCount < 5)
                return;

            //check if result is successful
            //if not we don't need to read any identity properties to the serialization context
            if (Result != LoginResult.Success)
                return;

            var name = info.GetString(nameof(Identity.Name));
            var userId = info.GetInt32(nameof(Identity.UserId));
            var authenticationType = info.GetString(nameof(Identity.AuthenticationType));
            var role = (Gizmo.Server.UserRoles)info.GetValue(nameof(Identity.Role), typeof(Gizmo.Server.UserRoles));

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

            //check if result is successful
            //if not we don't need to add any identity properties to the serialization context
            if (Result != LoginResult.Success || Identity == null)
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
        public sealed class SerializableClaim
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

            string _claimType;
            string _claimValue;

            #endregion

            #region PROPERTIES

            public string Type
            {
                get { return _claimValue; }
                protected set { _claimValue = value; }
            }

            public string Value
            {
                get { return _claimType; }
                protected set { _claimType = value; }
            }

            #endregion
        }
        #endregion
    }
}
