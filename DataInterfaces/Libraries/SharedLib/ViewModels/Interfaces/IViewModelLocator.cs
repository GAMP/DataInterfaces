using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// View model locator interface.
    /// </summary>
    public interface IViewModelLocator<T>
    {
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
        /// This item source should implement observable pattern.
        /// </summary>
        IEnumerable<T> EnumerableSource { get; }
    }

    /// <summary>
    /// View model locator interface.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public interface IViewModelLocatorList<T> : IViewModelLocator<T>
    {
        /// <summary>
        /// Gets item source that can be used for binding and manipulation.
        /// </summary>
        IList<T> ListSource { get; }
    }
}
