using SharedLib.ViewModels;

namespace Manager.ViewModels
{
    /// <summary>
    /// Exposed by user model locator.
    /// </summary>
    public interface IUserViewModelLocator : IViewModelLocator<IUserMemberViewModel>
    {
        /// <summary>
        /// Checks if user with specified username exists.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="exclude">User id to excluse from search.</param>
        /// <returns>True or false.</returns>
        bool UserExists(string userName, int exclude);

        /// <summary>
        /// Checks if user with specified username exists.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="excludedUser">User id to excluse from search.</param>
        /// <returns>True or false.</returns>
        bool UserEmailExists(string email, int excludedUser);
    }
}
