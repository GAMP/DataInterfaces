using SharedLib;
using SharedLib.User;
using SkinInterfaces;

namespace Client.ViewModels
{
    /// <summary>
    /// User profile edit view model interface.
    /// </summary>
    public interface IUserProfileEditViewModel : ISourceConverter<IUserProfile>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets user first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets user mobile phone.
        /// </summary>
        string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets user phone.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets required user profile fields.
        /// </summary>
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

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <returns>True if model is valid , otherwise false.</returns>
        bool Validate();

        /// <summary>
        /// Resets validation errors.
        /// </summary>
        void ResetValidation();

        #endregion
    } 
}