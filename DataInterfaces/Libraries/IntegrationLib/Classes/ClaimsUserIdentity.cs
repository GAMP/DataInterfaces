using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region ClaimsUserIdentity
    [Serializable()]
    public class ClaimsUserIdentity : ClaimsIdentity, IUserIdentity
    {
        #region CONSTRUCTOR
        public ClaimsUserIdentity(int userId, UserRoles role, IEnumerable<Claim> claims)
            : base(claims)
        {
            this.Role = role;
            this.UserId = userId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets user role.
        /// </summary>
        public UserRoles Role
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion
}
