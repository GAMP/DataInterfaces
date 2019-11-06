using SharedLib.User;

namespace ServerService
{
    /// <summary>
    /// Temporary inteface do not implement.
    /// </summary>
    public interface IUserProfileHook
    {
        #region FUNCTIONS
        /// <summary>
        /// Post create profile function.
        /// </summary>
        /// <param name="profile">Created profile.</param>
        void PostUserProfileCreate(IUserProfile profile); 
        #endregion
    }
}
