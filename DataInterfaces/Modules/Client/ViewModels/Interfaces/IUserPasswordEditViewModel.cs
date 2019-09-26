using SkinInterfaces;

namespace Client.ViewModels
{
    /// <summary>
    /// User password edit view model interface.
    /// </summary>
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
