using SharedLib.ViewModels;

namespace Manager.ViewModels
{
    /// <summary>
    /// Manager menu item interface.
    /// </summary>
    public interface IManagerMenuItemViewModel : IMenuItemViewModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets menu item key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets menu item parent key.
        /// </summary>
        string ParentKey { get; } 

        #endregion
    }
}