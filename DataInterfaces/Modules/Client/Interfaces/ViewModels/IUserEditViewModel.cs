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
        #region PROPERTIES

        /// <summary>
        /// Gets or sets accept command.
        /// </summary>
        IExecutionChangedAwareCommand AcceptCommand { get; set; }

        /// <summary>
        /// Gets or sets cancel command.
        /// </summary>
        IExecutionChangedAwareCommand CancelCommand { get; set; }

        /// <summary>
        /// Gets current password.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Gets if model is valid.
        /// </summary>
        bool IsValid { get; }


        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <returns>True if model is valid , otherwise false.</returns>
        bool Validate(); 

        #endregion
    }
}