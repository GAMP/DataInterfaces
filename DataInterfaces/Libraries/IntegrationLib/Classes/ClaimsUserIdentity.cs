using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace IntegrationLib
{
    #region ClaimsUserIdentity
    /// <summary>
    /// Extends generic claims identity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ClaimsUserIdentity : ClaimsIdentity, IUserIdentity
    {
        #region CONSTRUCTOR

        public ClaimsUserIdentity(int userId)
        {
            UserId = userId;
        }

        public ClaimsUserIdentity(int userId, IEnumerable<Claim> claims)
            : base(claims)
        {
            UserId = userId;
        }

        public ClaimsUserIdentity(int userId,IEnumerable<Claim> claims,UserRoles role):this(userId,claims)
        {
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
    }
    #endregion
}
