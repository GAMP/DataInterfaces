using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Windows.Interop;

namespace SkinInterfaces
{
    #region DependencyObjectExtensions
    public static class DependencyObjectExtensions
    {
        public static T GetValue<T>(this DependencyObject obj, DependencyProperty dp)
        {
            return (T)obj.GetValue(dp);
        }

        public static DependencyObject GetLogicalParent(this DependencyObject obj)
        {
            return LogicalTreeHelper.GetParent(obj);
        }

        public static IEnumerable<DependencyObject> GetLogicalChildren(this DependencyObject obj)
        {
            return LogicalTreeHelper.GetChildren(obj).Cast<DependencyObject>();
        }

        public static DependencyObject GetVisualParent(this DependencyObject obj)
        {
            return VisualTreeHelper.GetParent(obj);
        }

        public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject obj)
        {
            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(obj, i);
            }
        }

        public static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !(tmp is T))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp as T;
        }

        public static DependencyObject FindAncestor(this DependencyObject obj, Type ancestorType)
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !ancestorType.IsAssignableFrom(tmp.GetType()))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp;
        }

        public static IEnumerable<T> FindDescendants<T>(this DependencyObject obj) where T : DependencyObject
        {
            var queue = new Queue<DependencyObject>(obj.GetVisualChildren());
            while (queue.Count > 0)
            {
                var child = queue.Dequeue();
                if (child is T)
                    yield return (T)child;
                foreach (var c in child.GetVisualChildren())
                {
                    queue.Enqueue(c);
                }
            }
        }

        public static IEnumerable<DependencyObject> FindDescendants(this DependencyObject obj, Type descendantType)
        {
            var queue = new Queue<DependencyObject>(obj.GetVisualChildren());
            while (queue.Count > 0)
            {
                var child = queue.Dequeue();
                if (descendantType.IsAssignableFrom(child.GetType()))
                    yield return child;
                foreach (var c in child.GetVisualChildren())
                {
                    queue.Enqueue(c);
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);

                    if (childOfChild != null)
                        return childOfChild;
                }
            }

            return null;
        }

        public static void AddPropertyChangedHandler(this DependencyObject obj, DependencyProperty property, EventHandler handler)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(property, obj.GetType());
            desc.AddValueChanged(obj, handler);
        }

        public static void RemovePropertyChangedHandler(this DependencyObject obj, DependencyProperty property, EventHandler handler)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(property, obj.GetType());
            desc.RemoveValueChanged(obj, handler);
        }

        public static T VisualUpwardSearch<T>(this DependencyObject source) where T : DependencyObject
        {
            DependencyObject returnVal = source;

            while (returnVal != null && !(returnVal is T))
            {
                DependencyObject tempReturnVal = null;
                if (returnVal is Visual || returnVal is Visual3D)
                {
                    tempReturnVal = VisualTreeHelper.GetParent(returnVal);
                }
                if (tempReturnVal == null)
                {
                    returnVal = LogicalTreeHelper.GetParent(returnVal);
                }
                else returnVal = tempReturnVal;
            }

            return returnVal as T;
        }
    } 
    #endregion

    #region FrameworkElementExtensions
    public static class FrameworkElementExtensions
    {
        public static void DoWhenLoaded(this FrameworkElement element, Action action)
        {
            if (element.IsLoaded)
            {
                action();
            }
            else
            {
                RoutedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    element.Loaded -= handler;
                    action();
                };
                element.Loaded += handler;
            }
        }

        public static void DoWhenLoaded<T>(this T element, Action<T> action)
            where T : FrameworkElement
        {
            if (element.IsLoaded)
            {
                action(element);
            }
            else
            {
                RoutedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    element.Loaded -= handler;
                    action(element);
                };
                element.Loaded += handler;
            }
        }
    } 
    #endregion

    #region SkinHelper
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
    #endregion

    #region UIElementExtensions
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

