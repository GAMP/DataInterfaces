using Manager.ViewModels;
using System;
using System.Collections.Generic;

namespace Manager.Services
{
    /// <summary>
    /// Manager menu service.
    /// Handles creation of menus in manager module.
    /// </summary>
    public interface IManagerMenuService
    { 
        /// <summary>
        /// Gets menu item by menu key.
        /// </summary>
        /// <param name="menuKey">Menu item key.</param>
        /// <returns>Menu item.</returns>
        IManagerMenuItemViewModel GetMenuItem(string menuKey);

        /// <summary>
        /// Tries to obtain menu item by menu key.
        /// </summary>
        /// <param name="menuKey">Menu item key.</param>
        /// <param name="menuItem">Found menu item.</param>
        /// <returns>True if menu item is found, otherwise false.</returns>
        bool TryGetMenuItem(string menuKey, out IManagerMenuItemViewModel menuItem);

        /// <summary>
        /// Gets menu item collection for specified area key.
        /// </summary>
        /// <param name="areaKey">Menu area key.</param>
        /// <returns>Collection of menu items.</returns>
        /// <remarks>
        /// The collection returned implments observable pattern and can be used for binding.
        /// </remarks>
        IEnumerable<IManagerMenuItemViewModel> GetMenus(string areaKey);

        /// <summary>
        /// Creates menu area.
        /// </summary>
        /// <param name="areaKey">Area key.</param>
        /// <returns>Associated area menu store collection.</returns>
        /// <remarks>
        /// If area with same key was previously created its store is returned.
        /// </remarks>
        IEnumerable<IManagerMenuItemViewModel> CreateMenuArea(string areaKey);

        /// <summary>
        /// Creates menu item.
        /// </summary>
        /// <param name="areaOrParentKey">Key of the menu area or parent menu key.</param>
        /// <param name="menuKey">New menu key.</param>
        /// <param name="header">Menu header.</param>
        /// <param name="isCheckable">Specifies if menu should be checkable.</param>
        /// <param name="iconResource">Menu icon resource string.</param>
        /// <param name="canExecuteAction">Action to execute when we need to determine if menu command can be executed.</param>
        /// <param name="executeAction">Execute action that will be executed when menu is clicked or checked.</param>
        /// <param name="parameter">Action parameter.</param>
        /// <returns>Created menu item.</returns>
        /// <remarks>
        /// When creating a menu item we first determine if an area with specified <paramref name="areaOrParentKey"/> exist and add the menu to specified area.
        /// If area with specified key does not exist then we try to obtain a menu item with specified key and add newly created menu item as child.
        /// Same area and menu key cannot be used multiple times and should always be unique.
        /// </remarks>
        IManagerMenuItemViewModel CreateMenu(string areaOrParentKey,
            string menuKey,
            string header,
            bool isCheckable,
            string iconResource,
            Func<object, bool> canExecuteAction,
            Action<object> executeAction,
            object parameter);

        /// <summary>
        /// Creates menu item.
        /// </summary>
        /// <param name="areaOrParentKey">Key of the menu area or parent menu key.</param>
        /// <param name="menuKey">New menu key.</param>
        /// <param name="header">Menu header.</param>
        /// <returns>Created menu item.</returns>
        IManagerMenuItemViewModel CreateMenu(string areaOrParentKey,
            string menuKey,
            string header);

        /// <summary>
        /// Creates menu item.
        /// </summary>
        /// <param name="areaOrParentKey">Key of the menu area or parent menu key.</param>
        /// <param name="menuKey">New menu key.</param>
        /// <param name="header">Menu header.</param>
        /// <param name="isCheckable">Specifies if menu should be checkable.</param>
        /// <returns>Created menu item.</returns>
        IManagerMenuItemViewModel CreateMenu(string areaOrParentKey,
           string menuKey,
           string header,
           bool isCheckable);

        /// <summary>
        /// Creates menu item.
        /// </summary>
        /// <param name="areaOrParentKey">Key of the menu area or parent menu key.</param>
        /// <param name="menuKey">New menu key.</param>
        /// <param name="header">Menu header.</param>
        /// <param name="isCheckable">Specifies if menu should be checkable.</param>
        /// <param name="iconResource">Menu icon resource string.</param>
        /// <returns>Created menu item.</returns>
        IManagerMenuItemViewModel CreateMenu(string areaOrParentKey,
           string menuKey,
           string header,
           bool isCheckable,
           string iconResource);

        /// <summary>
        /// Creates menu item.
        /// </summary>
        /// <param name="areaOrParentKey">Key of the menu area or parent menu key.</param>
        /// <param name="menuKey">New menu key.</param>
        /// <param name="header">Menu header.</param>
        /// <param name="isCheckable">Specifies if menu should be checkable.</param>
        /// <param name="iconResource">Menu icon resource string.</param>
        /// <param name="canExecuteAction">Action to execute when we need to determine if menu command can be executed.</param>
        /// <param name="executeAction">Execute action that will be executed when menu is clicked or checked.</param>
        /// <returns>Created menu item.</returns>
        IManagerMenuItemViewModel CreateMenu(string areaOrParentKey,
           string menuKey,
           string header,
           bool isCheckable,
           string iconResource,
           Func<object, bool> canExecuteAction,
           Action<object> executeAction);
    }
}
