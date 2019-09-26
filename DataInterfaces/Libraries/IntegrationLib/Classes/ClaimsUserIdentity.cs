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
    public class ClaimsUserIdentity : GenericIdentity, IUserIdentity
    {
        #region CONSTRUCTOR

        public ClaimsUserIdentity(string name, int userId, UserRoles role)
         : this(name,userId,role, Enumerable.Empty<Claim>())
        {
        }

        public ClaimsUserIdentity(string name, int userId, UserRoles role, IEnumerable<Claim> claims):base(name)
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
    }
}
