using Manager.Services;
using SharedLib.ViewModels;
using SharedLib.Views;
using System;
using System.Collections.Generic;

namespace Manager.Services
{
    public interface IManagerMenuService
    {
       
        /// <summary>
        /// Gets menu item by id.
        /// </summary>
        /// <param name="menuId">Menu item id.</param>
        /// <returns>Menu item.</returns>
        IMenuItemViewModel GetMenuItem(int menuId);

        /// <summary>
        /// Gets menu item by key.
        /// </summary>
        /// <param name="menuKey">Menu item key.</param>
        /// <returns>Menu item.</returns>
        IMenuItemViewModel GetMenuItem(string menuKey);

        /// <summary>
        /// Tries to obtain menu item by key.
        /// </summary>
        /// <param name="menuKey">Menu item key.</param>
        /// <param name="menuItem">Found menu item.</param>
        /// <returns>True if menu item is found, otherwise false.</returns>
        bool TryGetMenuItem(string menuKey, out IMenuItemViewModel menuItem);

        /// <summary>
        /// Tries to obtain menu item by id.
        /// </summary>
        /// <param name="menuId">Menu item id.</param>
        /// <param name="menuItem">Found menu item.</param>
        /// <returns>True if menu item is found, otherwise false.</returns>
        bool TryGetMenuItem(int menuId, out IMenuItemViewModel menuItem);

        /// <summary>
        /// Gets menu item collection for specified area key.
        /// </summary>
        /// <param name="areaKey">Menu area key.</param>
        /// <returns>Collection of menu items.</returns>
        IEnumerable<IMenuItemViewModel> GetMenus(KnownMenuArea areaKey);

        /// <summary>
        /// Gets menu item collection for specified area key.
        /// </summary>
        /// <param name="areaKey">Menu area key.</param>
        /// <returns>Collection of menu items.</returns>
        IEnumerable<IMenuItemViewModel> GetMenus(string areaKey);

        /// <summary>
        /// Ensures that menu area is registered and returns current area store.
        /// </summary>
        /// <param name="areaKey">Area name.</param>
        /// <returns>Area associated store.</returns>
        IList<IMenuItemViewModel> EnsureMenuAreaStore(string areaKey);

        IMenuItemViewModel CreateMenu(KnownMenuArea areaKey, 
            string menuKey,
            string header,
            bool isCheckable,
            string iconResource,
            Func<object, bool> canExecuteAction,
            Action<object> executeAction,
            object parameter);
        
        IMenuItemViewModel CreateMenu(string areaKey,
            string menuKey,
            string header,
            bool isCheckable,
            string iconResource,
            Func<object, bool> canExecuteAction,
            Action<object> executeAction,
            object parameter);
        
        IMenuItemViewModel CreateMenu(int parentId,
            string header,
            bool isCheckable,
            string iconResource,
            Func<object, bool> canExecuteAction,
            Action<object> executeAction,
            object parameter);

        /// <summary>
        /// Deletes specified menu.
        /// </summary>
        /// <param name="menuId"></param>
        void DeleteMenu(int menuId);
    }
}
