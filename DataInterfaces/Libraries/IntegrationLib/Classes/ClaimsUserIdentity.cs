using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace IntegrationLib
{
    #region ClaimsUserIdentity
    [Serializable()]
    [DataContract()]
    public class ClaimsUserIdentity : ClaimsIdentity, IUserIdentity
    {
        #region CONSTRUCTOR

        public ClaimsUserIdentity(int userId)
        {
            this.UserId = userId;
        }

        public ClaimsUserIdentity(int userId, IEnumerable<Claim> claims)
            : base(claims)
        {
            this.UserId = userId;
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
            private set;
        }

        /// <summary>
        /// Gets user role.
        /// </summary>
        [DataMember(Order = 1)]
        public UserRoles Role
        {
            get
            {
                return UserRoles.None;
            }
        }

        #endregion
    }
    #endregion
}
