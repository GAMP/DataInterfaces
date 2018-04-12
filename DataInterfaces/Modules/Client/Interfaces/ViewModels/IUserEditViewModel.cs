using SharedLib;
using SharedLib.User;
using SkinInterfaces;

namespace Client.ViewModels
{
    public interface IUserProfileEditViewModel : ISourceConverter<IUserProfile>
    {
        string Email { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string MobilePhone { get; set; }

        string Phone { get; set; }

        UserInfoTypes RequiredUserInfo { get; set; }

        /// <summary>
        /// Gets or sets accept command.
        /// </summary>
        IExecutionChangedAwareCommand AcceptCommand { get; set; }

        /// <summary>
        /// Gets or sets cancel command.
        /// </summary>
        IExecutionChangedAwareCommand CancelCommand { get; set; }

        /// <summary>
        /// Gets if model is valid.
        /// </summary>
        bool IsValid { get; }

        bool Validate();
    }

    public interface IUserPasswordEditViewModel
    {
        string Password { get; }

        /// <summary>
        /// Gets or sets accept command.
        /// </summary>
        IExecutionChangedAwareCommand AcceptCommand { get; set; }

        /// <summary>
        /// Gets or sets cancel command.
        /// </summary>
        IExecutionChangedAwareCommand CancelCommand { get; set; }

        bool IsValid { get; }

        bool Validate();
    }
}