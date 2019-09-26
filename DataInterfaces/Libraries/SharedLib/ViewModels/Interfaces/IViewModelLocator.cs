using System.Collections.Generic;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// View model locator interface.
    /// </summary>
    public interface IViewModelLocator<T>
    {
        #region PROPERTIES
        
        /// <summary>
        /// Tries to obtain view model.
        /// </summary>
        /// <param name="itemId">Item id.</param>
        /// <returns>ViewModel instance, should return null in case no view model found.</returns>
        T TryGetViewModel(int itemId);

        /// <summary>
        /// Gets all view models.
        /// </summary>
        IEnumerable<T> Get();

        /// <summary>
        /// Gets item source that can be used for binding.
        /// When implemented this enumerable should implement observable pattern.
        /// </summary>
        IEnumerable<T> EnumerableSource { get; } 

        #endregion
    }
}
