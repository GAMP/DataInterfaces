using SharedLib;
using SharedLib.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Manager.Services
{
    public interface IUserManagerService
    {
        void UserCreate(IUserProfile profile);
        IUserProfile UserGet(int userId);
        byte[] UserGetPicture(int userId);
        void UserLogin(int userId, int hostId);
        void UserLogout(int userId);
        void UserRemove(int userId);
        void UserRename(int userId, string newUserName);
        void UserSetEmail(int userId, string newUserEmail);
        void UserSetGroup(int userId, int newGroup);
        void UserSetPassword(int userId, string newPassword);
        void UserSetPicture(int userId, byte[] imageData);
        void UserSetRole(int userId, UserRoles role);
        void UserEnable(int userId, bool enable);
        IEnumerable<IUserProfile> UserGet();
        IEnumerable<IUserProfile> UserGet(IEnumerable<Filter> filterList);
        void UserUpdate(IUserProfile profile);
    }
}
