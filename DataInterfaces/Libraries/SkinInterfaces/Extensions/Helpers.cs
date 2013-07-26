using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Interop;

namespace SkinInterfaces
{
    /// <summary>
    /// Generic helper functions class.
    /// </summary>
    public class SkinHelper
    {
        /// <summary>
        /// Sets visual state of object.
        /// </summary>
        /// <param name="VisualState"></param>
        /// <param name="target"></param>
        /// <remarks></remarks>
        public static void SetVisualState(ElementVisualState VisualState, DependencyObject target)
        {
            target.SetValue(ExternalProperties.VisualStateProperty, VisualState);
        }

        /// <summary>
        /// Brings the object on top of other objects.
        /// </summary>
        /// <param name="Target"></param>
        /// <remarks>Use this function to bring the object on top of others.</remarks>
        /// <returns>True in case of success False in case of failure.</returns>
        public static bool BringToTop(DependencyObject Target)
        {
            try
            {
                //Find sender visual parent
                DependencyObject VisualParent = VisualTreeHelper.GetParent(Target);
                if (VisualParent == null)
                {
                    return false;
                }
                UIElement CurrentTopObject;
                int CurrentTopIndex = 0;
                foreach (UIElement Child in ((Grid)VisualParent).Children)
                {
                    int UiElementZindex = (int)Child.GetValue(Canvas.ZIndexProperty);
                    if (UiElementZindex >= CurrentTopIndex)
                    {
                        CurrentTopIndex = UiElementZindex;
                        CurrentTopObject = Child;
                    }
                }
                if (CurrentTopIndex == 0)
                {
                    CurrentTopIndex = 1;
                }
                else
                {
                    foreach (UIElement Child in ((Grid)VisualParent).Children)
                    {
                        Child.SetValue(Canvas.ZIndexProperty, (int)Child.GetValue(Canvas.ZIndexProperty) - 1);
                    }
                }
                Canvas.SetZIndex((UIElement)Target, CurrentTopIndex);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Recursevly seraches for first topmost instance of the parent control of the DependencyObject.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public static UserControl FindParentControl(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent == null) return null;
            UserControl parentControl = parent as UserControl;
            if (parentControl != null)
            {
                return parentControl;
            }
            else
            {
                return FindParentControl(parent);
            }
        }

        /// <summary>
        /// Finds the parent window of DependencyObject.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public static Window FindParentWindow(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent == null) return null;
            Window parentControl = parent as Window;
            if (parentControl != null)
            {
                return parentControl;
            }
            else
            {
                return FindParentWindow(parent);
            }
        }

        /// <summary>
        /// Finds the first Parent taht implements ICustomComponent of the visual.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ICustomComponent FindParentComponent(DependencyObject element)
        {
            DependencyObject nextSearch = element;

            while (true)
            {
                if (nextSearch is Visual)
                {
                    DependencyObject parent = VisualTreeHelper.GetParent(nextSearch);
                    if (parent != null)
                    {
                        if (parent is ICustomComponent)
                        {
                            return parent as ICustomComponent;
                        }
                        else
                        {
                            nextSearch = parent;
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
            return null;
        }

        /// <summary>
        /// Gets the screen of the specified window.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static System.Windows.Forms.Screen GetScreen(Window window)
        {
            IntPtr windowHandle = new WindowInteropHelper(window).Handle;
            System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(windowHandle);
            return screen;
        }

        /// <summary>
        /// Gets the curent visual state of the DependencyObject.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ElementVisualState GetVisualState(DependencyObject element)
        {
            return (ElementVisualState)element.GetValue(ExternalProperties.VisualStateProperty);
        }

        /// <summary>
        /// Checks if DependencyObject zindexing is enabled.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool ZindexEnabled(DependencyObject element)
        {
            return (bool)element.GetValue(ExternalProperties.AllowZindexProperty);
        }

        /// <summary>
        /// Maximze the DependencyObject.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Maximize(DependencyObject element)
        {
            //Find sender visual parent
            DependencyObject VisualParent = VisualTreeHelper.GetParent(element);
            if (VisualParent == null)
            {
                return false;
            }
            else
            {
                ((FrameworkElement)element).Width = ((FrameworkElement)VisualParent).ActualWidth;
                ((FrameworkElement)element).Height = ((FrameworkElement)VisualParent).ActualHeight;
                ((FrameworkElement)element).Margin = new Thickness(0, 0, 0, 0);
                return true;
            }
        }

        /// <summary>
        /// Restore the DependencyObject to its original visual values.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Restore(DependencyObject element)
        {
            RestoreVisuals oldvisuals = (RestoreVisuals)((FrameworkElement)element).GetValue(InternalProperties.RestoreVisualsProperty);
            if (oldvisuals != null)
            {
                SkinHelper.SetRestoreVisuals((FrameworkElement)element, oldvisuals);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the curent visual values of the FrameworkElement.
        /// </summary>
        /// <remarks>
        /// This will also assing the restore visuals to the object so they can be obtained later on.
        /// </remarks>
        /// <param name="element"></param>
        /// <returns></returns>
        public static RestoreVisuals GetRestoreVisuals(FrameworkElement element)
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
        /// Sets the restore visuals values to the passed element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="visuals"></param>
        public static void SetRestoreVisuals(FrameworkElement element, RestoreVisuals visuals)
        {
            element.Width = visuals.Width;
            element.Height = visuals.Height;
            element.Opacity = visuals.Opacity;
            element.Margin = new Thickness(visuals.Margin.Left, visuals.Margin.Top, visuals.Margin.Right, visuals.Margin.Bottom);
        }

        /// <summary>
        /// Restore the FrameworkElement to the specified restore visuals.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="visuals"></param>
        /// <param name="restoreType"></param>
        public static void RestoreVisuals(FrameworkElement element, RestoreVisuals visuals, RestoreType restoreType)
        {
            if ((restoreType & RestoreType.Opacity) == RestoreType.Opacity)
            {
                element.Opacity = visuals.Opacity;
            }
        }
    }
}
