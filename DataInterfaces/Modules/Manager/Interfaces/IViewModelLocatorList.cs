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
    /// <typeparam name="T">Item type.</typeparam>
    public interface IViewModelLocatorList<T> : IViewModelLocator<T>
    {
        /// <summary>
        /// Gets item source that can be used for binding and manipulation.
        /// When implemented this list should implement observable pattern.
        /// </summary>
        IList<T> ListSource { get; }
    }
}
