using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace SkinInterfaces
{
    #region RestoreVisuals
    /// <summary>
    /// Generic class to restore controls visual options.
    /// This class can be used to restore original values of the control after animation.
    /// </summary>
    public class RestoreVisuals
    {
        public double Width
        {
            get;
            set;
        }
        public double Height
        {
            get;
            set;
        }
        public double Opacity
        {
            get;
            set;
        }
        public Thickness Margin
        {
            get;
            set;
        }
        public double ActualHeight
        {
            get;
            set;
        }
        public double ActualWidth
        {
            get;
            set;
        }
    }
    #endregion

    #region DeferredAction
    /// <summary>
    /// Represents a timer which performs an action on the UI thread when time elapses.  Rescheduling is supported.
    /// </summary>
    public class DeferredAction : IDisposable
    {
        private Timer timer;

        /// <summary>
        /// Creates a new DeferredAction.
        /// </summary>
        /// <param name="action">
        /// The action that will be deferred.  It is not performed until after <see cref="Defer"/> is called.
        /// </param>
        public static DeferredAction Create(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            return new DeferredAction(action);
        }

        private DeferredAction(Action action)
        {
            this.timer = new Timer(new TimerCallback(delegate
            {
                Application.Current.Dispatcher.Invoke(action);
            }));
        }

        /// <summary>
        /// Defers performing the action until after time elapses.  Repeated calls will reschedule the action
        /// if it has not already been performed.
        /// </summary>
        /// <param name="delay">
        /// The amount of time to wait before performing the action.
        /// </param>
        public void Defer(TimeSpan delay)
        {
            // Fire action when time elapses (with no subsequent calls).
            this.timer.Change(delay, TimeSpan.FromMilliseconds(-1));
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
                this.timer = null;
            }
        }

        #endregion
    }
    #endregion

    #region BindableParametersConverter
    public abstract class BindableParametersConverter : DependencyObject, IValueConverter
    {
        #region Fields
        public static DependencyProperty BindableConverterParameterProperty = DependencyProperty.Register("BindableConverterParameter", typeof(object),
          typeof(BindableParametersConverter));
        #endregion

        #region Properties
        [Description("Gets or sets converter parameter")]
        public object BindableConverterParameter
        {
            get { return (object)GetValue(BindableConverterParameterProperty); }
            set { SetValue(BindableConverterParameterProperty, value); }
        }
        #endregion

        #region Abstract Members

        public abstract object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);
        
        public abstract object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);
        
        #endregion
    } 
    #endregion

    #region VirtualToggleButton
    public static class VirtualToggleButton
    {
        #region attached properties

        #region IsChecked

        /// <summary>
        /// IsChecked Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.RegisterAttached("IsChecked", typeof(Nullable<bool>), typeof(VirtualToggleButton),
                new FrameworkPropertyMetadata((Nullable<bool>)false,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                    new PropertyChangedCallback(OnIsCheckedChanged)));

        /// <summary>
        /// Gets the IsChecked property.  This dependency property 
        /// indicates whether the toggle button is checked.
        /// </summary>
        public static Nullable<bool> GetIsChecked(DependencyObject d)
        {
            return (Nullable<bool>)d.GetValue(IsCheckedProperty);
        }

        /// <summary>
        /// Sets the IsChecked property.  This dependency property 
        /// indicates whether the toggle button is checked.
        /// </summary>
        public static void SetIsChecked(DependencyObject d, Nullable<bool> value)
        {
            d.SetValue(IsCheckedProperty, value);
        }

        /// <summary>
        /// Handles changes to the IsChecked property.
        /// </summary>
        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement pseudobutton = d as UIElement;
            if (pseudobutton != null)
            {
                Nullable<bool> newValue = (Nullable<bool>)e.NewValue;
                if (newValue == true)
                {
                    RaiseCheckedEvent(pseudobutton);
                }
                else if (newValue == false)
                {
                    RaiseUncheckedEvent(pseudobutton);
                }
                else
                {
                    RaiseIndeterminateEvent(pseudobutton);
                }
            }
        }

        #endregion

        #region IsThreeState

        /// <summary>
        /// IsThreeState Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsThreeStateProperty =
            DependencyProperty.RegisterAttached("IsThreeState", typeof(bool), typeof(VirtualToggleButton),
                new FrameworkPropertyMetadata((bool)false));

        /// <summary>
        /// Gets the IsThreeState property.  This dependency property 
        /// indicates whether the control supports two or three states.  
        /// IsChecked can be set to null as a third state when IsThreeState is true.
        /// </summary>
        public static bool GetIsThreeState(DependencyObject d)
        {
            return (bool)d.GetValue(IsThreeStateProperty);
        }

        /// <summary>
        /// Sets the IsThreeState property.  This dependency property 
        /// indicates whether the control supports two or three states. 
        /// IsChecked can be set to null as a third state when IsThreeState is true.
        /// </summary>
        public static void SetIsThreeState(DependencyObject d, bool value)
        {
            d.SetValue(IsThreeStateProperty, value);
        }

        #endregion

        #region IsVirtualToggleButton

        /// <summary>
        /// IsVirtualToggleButton Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsVirtualToggleButtonProperty =
            DependencyProperty.RegisterAttached("IsVirtualToggleButton", typeof(bool), typeof(VirtualToggleButton),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnIsVirtualToggleButtonChanged)));

        /// <summary>
        /// Gets the IsVirtualToggleButton property.  This dependency property 
        /// indicates whether the object to which the property is attached is treated as a VirtualToggleButton.  
        /// If true, the object will respond to keyboard and mouse input the same way a ToggleButton would.
        /// </summary>
        public static bool GetIsVirtualToggleButton(DependencyObject d)
        {
            return (bool)d.GetValue(IsVirtualToggleButtonProperty);
        }

        /// <summary>
        /// Sets the IsVirtualToggleButton property.  This dependency property 
        /// indicates whether the object to which the property is attached is treated as a VirtualToggleButton.  
        /// If true, the object will respond to keyboard and mouse input the same way a ToggleButton would.
        /// </summary>
        public static void SetIsVirtualToggleButton(DependencyObject d, bool value)
        {
            d.SetValue(IsVirtualToggleButtonProperty, value);
        }

        /// <summary>
        /// Handles changes to the IsVirtualToggleButton property.
        /// </summary>
        private static void OnIsVirtualToggleButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IInputElement element = d as IInputElement;
            if (element != null)
            {
                if ((bool)e.NewValue)
                {
                    element.MouseLeftButtonDown += OnMouseLeftButtonDown;
                    element.KeyDown += OnKeyDown;
                }
                else
                {
                    element.MouseLeftButtonDown -= OnMouseLeftButtonDown;
                    element.KeyDown -= OnKeyDown;
                }
            }
        }

        #endregion

        #endregion

        #region routed events

        #region Checked

        /// <summary>
        /// A static helper method to raise the Checked event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        internal static RoutedEventArgs RaiseCheckedEvent(UIElement target)
        {
            if (target == null) return null;

            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = ToggleButton.CheckedEvent;
            RaiseEvent(target, args);
            return args;
        }

        #endregion

        #region Unchecked

        /// <summary>
        /// A static helper method to raise the Unchecked event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        internal static RoutedEventArgs RaiseUncheckedEvent(UIElement target)
        {
            if (target == null) return null;

            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = ToggleButton.UncheckedEvent;
            RaiseEvent(target, args);
            return args;
        }

        #endregion

        #region Indeterminate

        /// <summary>
        /// A static helper method to raise the Indeterminate event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        internal static RoutedEventArgs RaiseIndeterminateEvent(UIElement target)
        {
            if (target == null) return null;

            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = ToggleButton.IndeterminateEvent;
            RaiseEvent(target, args);
            return args;
        }

        #endregion

        #endregion

        #region private methods

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            UpdateIsChecked(sender as DependencyObject);
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.OriginalSource == sender)
            {
                if (e.Key == Key.Space)
                {
                    // ignore alt+space which invokes the system menu
                    if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) return;

                    UpdateIsChecked(sender as DependencyObject);
                    e.Handled = true;

                }
                else if (e.Key == Key.Enter && (bool)(sender as DependencyObject).GetValue(KeyboardNavigation.AcceptsReturnProperty))
                {
                    UpdateIsChecked(sender as DependencyObject);
                    e.Handled = true;
                }
            }
        }

        private static void UpdateIsChecked(DependencyObject d)
        {
            Nullable<bool> isChecked = GetIsChecked(d);
            if (isChecked == true)
            {
                SetIsChecked(d, GetIsThreeState(d) ? (Nullable<bool>)null : (Nullable<bool>)false);
            }
            else
            {
                SetIsChecked(d, isChecked.HasValue);
            }
        }

        private static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
        {
            if (target is UIElement)
            {
                (target as UIElement).RaiseEvent(args);
            }
            else if (target is ContentElement)
            {
                (target as ContentElement).RaiseEvent(args);
            }
        }

        #endregion
    } 
    #endregion

    public static class SizeObserver
    {
        #region " Observe "

        public static bool GetObserve(FrameworkElement elem)
        {
            return (bool)elem.GetValue(ObserveProperty);
        }

        public static void SetObserve(
          FrameworkElement elem, bool value)
        {
            elem.SetValue(ObserveProperty, value);
        }

        public static readonly DependencyProperty ObserveProperty =
            DependencyProperty.RegisterAttached("Observe", typeof(bool), typeof(SizeObserver),
            new UIPropertyMetadata(false, OnObserveChanged));

        static void OnObserveChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement elem = depObj as FrameworkElement;
            if (elem == null)
                return;

            if (e.NewValue is bool == false)
                return;

            if ((bool)e.NewValue)
                elem.SizeChanged += OnSizeChanged;
            else
                elem.SizeChanged -= OnSizeChanged;
        }

        static void OnSizeChanged(object sender, RoutedEventArgs e)
        {
            if (!Object.ReferenceEquals(sender, e.OriginalSource))
                return;

            FrameworkElement elem = e.OriginalSource as FrameworkElement;
            if (elem != null)
            {
                SetObservedWidth(elem, elem.ActualWidth);
                SetObservedHeight(elem, elem.ActualHeight);
            }
        }

        #endregion

        #region " ObservedWidth "

        public static double GetObservedWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(ObservedWidthProperty);
        }

        public static void SetObservedWidth(DependencyObject obj, double value)
        {
            obj.SetValue(ObservedWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for ObservedWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObservedWidthProperty =
            DependencyProperty.RegisterAttached("ObservedWidth", typeof(double), typeof(SizeObserver), new UIPropertyMetadata(0.0));

        #endregion

        #region " ObservedHeight "

        public static double GetObservedHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ObservedHeightProperty);
        }

        public static void SetObservedHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ObservedHeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for ObservedHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObservedHeightProperty =
            DependencyProperty.RegisterAttached("ObservedHeight", typeof(double), typeof(SizeObserver), new UIPropertyMetadata(0.0));

        #endregion
    }
}
