using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace SkinInterfaces
{
    #region Extensions UI
    /// <summary>
    /// UIElement extensions.
    /// </summary>
    public static class UIElementExtensions
    {
        /// <summary>
        /// Restores the visual element to its previous Visual State.
        /// </summary>
        public static bool Restore(this UIElement element)
        {
            RestoreVisuals oldvisuals = (RestoreVisuals)((UIElement)element).GetValue(InternalProperties.RestoreVisualsProperty);
            if (oldvisuals != null)
            {
                SkinHelper.SetRestoreVisuals((FrameworkElement)element, oldvisuals);
                return true;
            }
            else
            {
                //could not obtain the visuals
                return false;
            }
        }

        /// <summary>
        /// Restore a visual state of specified properties.
        /// </summary>
        public static bool Restore(this UIElement element, RestoreType restoreType)
        {
            RestoreVisuals oldvisuals = (RestoreVisuals)((UIElement)element).GetValue(InternalProperties.RestoreVisualsProperty);
            if (oldvisuals != null)
            {
                SkinHelper.RestoreVisuals((FrameworkElement)element, oldvisuals, restoreType);
                return true;
            }
            else
            {
                //could not obtain the visuals
                return false;
            }
        }

        /// <summary>
        /// Saves and returns the elements restore visuals.
        /// </summary>
        public static RestoreVisuals SaveVisuals(this FrameworkElement element)
        {
            RestoreVisuals defaults = new RestoreVisuals();
            defaults.Width = element.Width;
            defaults.Height = element.Height;
            defaults.Margin = element.Margin;
            defaults.Opacity = element.Opacity;
            defaults.ActualHeight = element.ActualHeight;
            defaults.ActualWidth = element.ActualWidth;
            element.SetValue(InternalProperties.RestoreVisualsProperty, defaults);
            return defaults;
        }

        /// <summary>
        /// Checks if element is maximized.
        /// </summary>
        public static bool IsMaximized(this UIElement element)
        {
            return (bool)element.GetValue(ExternalProperties.IsMaximizedProperty);
        }

        /// <summary>
        /// Sets the elements Maximized state value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void IsMaximized(this UIElement element, bool value)
        {
            element.SetValue(ExternalProperties.IsMaximizedProperty, value);
        }

        /// <summary>
        /// Gets if the control draging is enabled.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsDragEnabled(this UIElement element)
        {
            return (bool)element.GetValue(InternalProperties.IsDragEnabledProperty);
        }

        /// <summary>
        /// Enables or disables controls dragging.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void IsDragEnabled(this UIElement element, bool value)
        {
            element.SetValue(InternalProperties.IsDragEnabledProperty, value);
        }

        /// <summary>
        /// Gets if the control resizing is enabled.
        /// </summary>
        public static bool IsResizeEnabled(this UIElement element)
        {
            return (bool)element.GetValue(InternalProperties.IsResizeEnabledProperty);
        }

        /// <summary>
        /// Enables or disables controls resizing.
        /// </summary>
        public static void IsResizeEnabled(this UIElement element, bool value)
        {
            element.SetValue(InternalProperties.IsResizeEnabledProperty, value);
        }

        /// <summary>
        /// Gets if the control zindexing is enabled.
        /// </summary>
        public static bool IsZIndexEnabled(this UIElement element)
        {
            return (bool)element.GetValue(InternalProperties.IsZindexEnabledProperty);
        }

        /// <summary>
        /// Enables or disables controls zindexing.
        /// </summary>
        public static void IsZIndexEnabled(this UIElement element, bool value)
        {
            element.SetValue(InternalProperties.IsZindexEnabledProperty, value);
        }

        /// <summary>
        /// Checks if element is active.
        /// </summary>
        public static bool IsActive(this UIElement element)
        {
            return (bool)element.GetValue(InternalProperties.IsActiveElementProperty);
        }

        /// <summary>
        /// Sets the lemenets isActive state.
        /// </summary>
        public static void IsActive(this UIElement element, bool value)
        {
            element.SetValue(InternalProperties.IsActiveElementProperty, value);
        }

        /// <summary>
        /// Gets an instance of the elements current restore visuals.
        /// </summary>
        public static RestoreVisuals RestoreVisuals(this UIElement element)
        {
            return (RestoreVisuals)element.GetValue(InternalProperties.RestoreVisualsProperty);
        }

        /// <summary>
        /// Gets the elements visual state.
        /// </summary>
        public static ElementVisualState VisualState(this UIElement element)
        {
            return (ElementVisualState)element.GetValue(ExternalProperties.VisualStateProperty);
        }

        public static void VisualState(this UIElement element, ElementVisualState newState)
        {
            element.SetValue(ExternalProperties.VisualStateProperty, (ElementVisualState)newState);
        }

        public static void Minimize(this UIElement element)
        {
            element.SetValue(ExternalProperties.VisualStateProperty, ElementVisualState.Minimized);
        }

        /// <summary>
        /// Freeze the elements properties.
        /// </summary>
        public static void Freeze(this UIElement element)
        {
            element.IsDragEnabled(false);
            element.IsResizeEnabled(false);
        }

        /// <summary>
        /// UnFreeze the elements properties.
        /// </summary>
        public static void UnFreeze(this UIElement element)
        {
            //only enable if allowed
            if ((bool)element.GetValue(ExternalProperties.AllowDragProperty) == true)
            {
                element.IsDragEnabled(true);
            }
            if ((bool)element.GetValue(ExternalProperties.AllowResizeProperty) == true)
            {
                element.IsResizeEnabled(true);
            }
        }

        /// <summary>
        /// Gets the GUID of the element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static String GUID(this UIElement element)
        {
            return (String)element.GetValue(ExternalProperties.GUIDProperty);
        }

        public static bool IsDragAllowed(this UIElement element)
        {
            return (bool)element.GetValue(ExternalProperties.AllowDragProperty);
        }

        public static bool IsAdorned(this UIElement element)
        {
            return (bool)element.GetValue(ExternalProperties.IsAdornedProperty);
        }

        public static bool IsBackground(this UIElement element)
        {
            return (bool)element.GetValue(ExternalProperties.IsBackgroundProperty);
        }

        public static void IsBackground(this UIElement element, bool value)
        {
            element.SetValue(ExternalProperties.IsBackgroundProperty, value);
        }

        public static bool IsSendToBackgroundAllowed(this UIElement element)
        {
            return (bool)element.GetValue(ExternalProperties.AllowSendToBackgroundProperty);
        }

        public static void IsSendToBackgroundAllowed(this UIElement element, bool value)
        {
            element.SetValue(ExternalProperties.AllowSendToBackgroundProperty, value);
        }
    } 
    #endregion
}
