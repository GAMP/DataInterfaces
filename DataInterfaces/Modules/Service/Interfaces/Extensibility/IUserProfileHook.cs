using SharedLib.User;

namespace ServerService
{
    /// <summary>
    /// Temporary inteface do not implement.
    /// </summary>
    public interface IUserProfileHook
    {
        void PostUserProfileCreate(IUserProfile profile);
    }
}
