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
        public int UserId
        {
            get;
            private set;
        }

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
