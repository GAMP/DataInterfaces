using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using SharedLib;

namespace IntegrationLib
{
    /// <summary>
    /// User identity interface.
    /// </summary>
    public interface IUserIdentity : IIdentity
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets identity user id.
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// Gets identity user role.
        /// </summary>
        UserRoles Role { get; } 

        /// <summary>
        /// Gets user claims.
        /// </summary>
        IEnumerable<Claim> Claims { get; }

        #endregion
    }
}
