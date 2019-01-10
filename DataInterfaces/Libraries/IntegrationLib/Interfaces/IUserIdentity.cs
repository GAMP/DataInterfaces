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

        #endregion
    }
}
