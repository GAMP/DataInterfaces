using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;

namespace IntegrationLib
{
    /// <summary>
    /// Extends generic claims identity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ClaimsUserIdentity : GenericIdentity, IUserIdentity , ISerializable
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="userId">User id.</param>
        /// <param name="role">User role.</param>
        public ClaimsUserIdentity(string name, int userId, UserRoles role)
         : this(name, userId, role, Enumerable.Empty<Claim>())
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="userId">User id.</param>
        /// <param name="role">User role.</param>
        /// <param name="claims">User claims.</param>
        public ClaimsUserIdentity(string name, int userId, UserRoles role, IEnumerable<Claim> claims) : base(name)
        {
            AddClaims(claims);
            UserId = userId;
            Role = role;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        [DataMember(Order = 0)]
        public int UserId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets user role.
        /// </summary>
        [DataMember(Order = 1)]
        public UserRoles Role
        {
            get;
            protected set;
        }

        #endregion

        #region ISerializable

        public ClaimsUserIdentity(SerializationInfo info, StreamingContext context)
            :base(info.GetString(nameof(Name)), info.GetString(nameof(AuthenticationType)))
        {
            //get user id
            UserId= info.GetInt32(nameof(UserId));

            //get user role
            Role = (UserRoles)info.GetValue(nameof(Role), typeof(UserRoles));

            //get claims collection
            //TEMPORARY reusing the class from auth result so we dont break compatibility with older builds
            var claims = (IEnumerable<AuthResult.SerializableClaim>)info.GetValue(nameof(Claims), typeof(IEnumerable<AuthResult.SerializableClaim>));

            //create claim list
            var userClaims = claims.Select(cl => new Claim(cl.Type, cl.Value)).ToList();

            //add user claims
            AddClaims(userClaims);  
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(UserId), UserId);
            info.AddValue(nameof(AuthenticationType), AuthenticationType);
            info.AddValue(nameof(Role), Role);
            info.AddValue(nameof(Claims), Claims.Select(e => new AuthResult.SerializableClaim(e.Type, e.Value)).ToList());
        }

        #endregion
    }
}
