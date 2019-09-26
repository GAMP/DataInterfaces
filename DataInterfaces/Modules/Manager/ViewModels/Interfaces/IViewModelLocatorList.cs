using System.Collections.Generic;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// View model locator interface.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public interface IViewModelLocatorList<T> : IViewModelLocator<T>
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets item source that can be used for binding and manipulation.
        /// When implemented this list should implement observable pattern.
        /// </summary>
        IList<T> ListSource { get; } 

        #endregion
    }
}
