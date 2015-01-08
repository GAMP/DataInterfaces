using System;
using System.Security.Principal;
using SharedLib;

namespace IntegrationLib
{
    /// <summary>
    /// User identity interface.
    /// </summary>
    public interface IUserIdentity : IIdentity
    {
        /// <summary>
        /// Gets identity user id.
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// Gets identity user role.
        /// </summary>
        [Obsolete("Roles will be removed in upcoming version.")]
        UserRoles Role { get; }
    }
}
