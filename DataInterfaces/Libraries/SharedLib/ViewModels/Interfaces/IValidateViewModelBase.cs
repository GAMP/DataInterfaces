using System;
using System.ComponentModel;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// Validation supporting view model interface.
    /// </summary>
    public interface IValidateViewModelBase
    {
        #region EVENTS

        /// <summary>
        /// Occurs on errors change.
        /// </summary>
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if view model has validation errors.
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Gets if view model has self properties errors.
        /// </summary>
        bool HasSelfErrors { get; }

        /// <summary>
        /// Gets if view model is valid.
        /// </summary>
        bool IsValid { get; }

        #endregion        

        #region FUNCTIONS
        
        /// <summary>
        /// Validates view model.
        /// </summary>
        /// <returns>True for success otherwise false.</returns>
        bool Validate(); 

        #endregion
    }
}