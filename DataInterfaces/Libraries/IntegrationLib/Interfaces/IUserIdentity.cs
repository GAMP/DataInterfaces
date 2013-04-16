using System;
using System.Security.Principal;
using SharedLib;

namespace IntegrationLib
{
    public interface IUserIdentity : IIdentity
    {
        int UserId { get; }
        UserRoles Role { get; }
    }
}
