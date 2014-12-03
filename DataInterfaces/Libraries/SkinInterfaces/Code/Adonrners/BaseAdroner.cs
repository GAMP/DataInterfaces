using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;
using System.Windows.Data;
using SkinInterfaces.Converters;

namespace SkinInterfaces.Code
{
    public class ElementAdorner : Adorner
    {
        #region Fileds
        private double originalOpacity;
        Thumb resizeThumb;
        StackPanel panel = new StackPanel();
        VisualCollection visualChildren;
        private UIElement controlBox;
        #endregion

        #region Constructor
        public ElementAdorner(UIElement adornedElement, IControlBox controlBox)
            : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);

            FrameworkElement box = controlBox as FrameworkElement;
            this.controlBox = box;
            panel.Children.Add(box);
            panel.Orientation = Orientation.Vertical;
            visualChildren.Add(panel);

            // Call a helper method to initialize the Thumbs
            // with a customized cursors.
            BuildAdornerCorner(ref resizeThumb, Cursors.SizeNWSE);

            // Add handlers for resizing.

            resizeThumb.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
            this.ProcessControlBox(controlBox);
            this.MouseEnter += new MouseEventHandler(adornedElement_MouseEnter);
            this.MouseLeave += new MouseEventHandler(adornedElement_MouseLeave);
            this.AdornedElement.MouseEnter += new MouseEventHandler(adornedElement_MouseEnter);
            this.AdornedElement.MouseLeave += new MouseEventHandler(adornedElement_MouseLeave);
            this.Opacity = 0;

        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets the instance of the Control Box for this adorner.
        /// </summary>
        private UIElement ControlBox
        {
            get { return this.controlBox; }
        } 
        #endregion

        #region Event Handlers

        private void ProcessControlBox(IControlBox controlBox)
        {

            Binding dragBind = new Binding("AllowDrag");
            dragBind.Source = this.AdornedElement;
            controlBox.DragThumb.MouseLeftButtonDown += new MouseButtonEventHandler(DragThumb_MouseLeftButtonDown);
            controlBox.DragThumb.DragDelta += new DragDeltaEventHandler(DragDeltaEvent);
            controlBox.DragThumb.DragStarted += new DragStartedEventHandler(drag_DragStarted);
            controlBox.DragThumb.DragCompleted += new DragCompletedEventHandler(drag_DragCompleted);
            controlBox.MaximizeButton.Checked += new RoutedEventHandler(OnMaximizeButtonChecked);
            controlBox.MinimizeButton.Click += new RoutedEventHandler(OnMinimizeButtonClick);
            controlBox.CloseButton.Click += new RoutedEventHandler(OnCloseButtonClick);
            ControlBoxStatesConverter converter = new ControlBoxStatesConverter();
            BoolToVisibilityConverter boolVisConverter = new BoolToVisibilityConverter();

            Binding minimzeBinding = new Binding("SupportedVisualStates");
            minimzeBinding.Converter = converter;
            minimzeBinding.ConverterParameter = 1;
            minimzeBinding.Source = this.AdornedElement;
            minimzeBinding.Mode = BindingMode.TwoWay;
            controlBox.MinimizeButton.SetBinding(UIElement.VisibilityProperty, minimzeBinding);

            Binding maximizeBinding = new Binding("SupportedVisualStates");
            maximizeBinding.Converter = converter;
            maximizeBinding.ConverterParameter = 2;
            maximizeBinding.Source = this.AdornedElement;
            maximizeBinding.Mode = BindingMode.TwoWay;
            controlBox.MaximizeButton.SetBinding(UIElement.VisibilityProperty, minimzeBinding);

            Binding closeBinding = new Binding("SupportedVisualStates");
            closeBinding.Converter = converter;
            closeBinding.ConverterParameter = 3;
            closeBinding.Source = this.AdornedElement;
            closeBinding.Mode = BindingMode.TwoWay;
            controlBox.CloseButton.SetBinding(UIElement.VisibilityProperty, closeBinding);

            Binding allowDragBinding = new Binding("AllowDrag");
            allowDragBinding.Converter = boolVisConverter;
            allowDragBinding.Source = this.AdornedElement;
            allowDragBinding.Mode = BindingMode.TwoWay;
            controlBox.DragThumb.SetBinding(UIElement.VisibilityProperty, allowDragBinding);

            Binding allowPinBinding = new Binding("AllowSendToBackground");
            allowPinBinding.Converter = boolVisConverter;
            allowPinBinding.Source = this.AdornedElement;
            allowPinBinding.Mode = BindingMode.TwoWay;
            controlBox.SendToBackgroundButton.SetBinding(UIElement.VisibilityProperty, allowPinBinding);

            Binding isPinnnedBinding = new Binding("IsBackground");
            isPinnnedBinding.Source = this.AdornedElement;
            isPinnnedBinding.Mode = BindingMode.TwoWay;
            controlBox.SendToBackgroundButton.SetBinding(ToggleButton.IsCheckedProperty, isPinnnedBinding);

            Binding allowResizing = new Binding("AllowResize");
            allowResizing.Converter = boolVisConverter;
            allowResizing.Source = this.AdornedElement;
            allowResizing.Mode = BindingMode.TwoWay;
            resizeThumb.SetBinding(UIElement.VisibilityProperty, allowResizing);
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.ControlBox.Visibility = Visibility.Collapsed;
            this.AdornedElement.Minimize();
        }

        private void OnMaximizeButtonChecked(object sender, RoutedEventArgs e)
        {

        } 

        #endregion

        #region Control Box Elements Events

        void DragThumb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.AdornedElement.IsActive(true);
        }
        void adornedElement_MouseLeave(object sender, MouseEventArgs e)
        {
            this.AnimateOut();
        }
        void adornedElement_MouseEnter(object sender, MouseEventArgs e)
        {
            this.AnimateIn();
        }

        #endregion

        #region Animation
        private void AnimateIn()
        {
            DoubleAnimation ani = new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(250)));
            this.BeginAnimation(OpacityProperty, ani);
        }
        private void AnimateOut()
        {
            if (!this.ControlBox.IsMouseOver)
            {
                DoubleAnimation ani = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(250)));

                this.BeginAnimation(OpacityProperty, ani);
                ani.Completed += new EventHandler(ani_Completed);
            }
        }
        void ani_Completed(object sender, EventArgs e)
        {
   
        }
        #endregion       

        #region Internal Helper Functions
        private void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
        {
            if (cornerThumb != null) return;
            cornerThumb = new Thumb();
            cornerThumb.Opacity = 0;
            // Set some arbitrary visual characteristics.
            cornerThumb.Cursor = customizedCursor;
            cornerThumb.Height = cornerThumb.Width = 16;
            visualChildren.Add(cornerThumb);
        }
        // This method ensures that the Widths and Heights are initialized.  Sizing to content produces
        // Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height
        // need to be set first.  It also sets the maximum size of the adorned element.
        private void EnforceSize(FrameworkElement adornedElement)
        {
            if (adornedElement.Width.Equals(Double.NaN))
                adornedElement.Width = adornedElement.DesiredSize.Width;
            if (adornedElement.Height.Equals(Double.NaN))
                adornedElement.Height = adornedElement.DesiredSize.Height;
        }
        private DependencyObject ParentObject()
        {
            return VisualTreeHelper.GetParent(this);
        }
        #endregion

        #region Overides
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
        protected override Size ArrangeOverride(Size finalSize)
        {
            // desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
            // These will be used to place the ResizingAdorner at the corners of the adorned element.  
            double desiredWidth = (AdornedElement as FrameworkElement).ActualWidth;
            double desiredHeight = (AdornedElement as FrameworkElement).ActualHeight;
            // adornerWidth & adornerHeight are used for placement as well.
            double adornerWidth = this.DesiredSize.Width;
            double adornerHeight = this.DesiredSize.Height;
            panel.Arrange(new Rect(adornerWidth / 2 + panel.DesiredSize.Width / 2 + 2, 0, desiredWidth, desiredHeight));
            resizeThumb.Arrange(new Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));
            if (finalSize.Height < panel.ActualHeight)
            {
                finalSize.Height = panel.ActualHeight;
            }
            // Return the final size.
            return finalSize;
        }
        #endregion

        #region Dragging
        public void DragDeltaEvent(object sender, DragDeltaEventArgs e)
        {
            try
            {
                //Find sender visual parent
                FrameworkElement VisualParent = this.AdornedElement as FrameworkElement;
                if ((VisualParent != null))
                {
                    if (!VisualParent.IsDragAllowed())
                    {
                        return;
                    }
                    VisualParent.Margin = new System.Windows.Thickness(Math.Round(VisualParent.Margin.Left + e.HorizontalChange),
                            Math.Round(VisualParent.Margin.Top + e.VerticalChange),
                            Math.Round(VisualParent.Margin.Right - e.HorizontalChange),
                            Math.Round(VisualParent.Margin.Bottom - e.VerticalChange));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in DragDeltaEvent Handler :" + ex.Message);
            }
        }
        void drag_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.AdornedElement.Opacity = this.originalOpacity;
        }
        void drag_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.originalOpacity = this.AdornedElement.Opacity;
            this.AdornedElement.Opacity = 0.5;
        }
        #endregion

        #region Resizing
        // Handler for resizing from the bottom-right.
        void HandleBottomRight(object sender, DragDeltaEventArgs args)
        {
            args.Handled = true;
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            // Ensure that the Width and Height are properly initialized after the resize.
            EnforceSize(adornedElement);

            Thickness old = (this.AdornedElement as FrameworkElement).Margin;
            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.
            double finalWidth = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            double finalHeight = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height);
            if (finalWidth <= (this.AdornedElement as FrameworkElement).MaxWidth && finalWidth >= (this.AdornedElement as FrameworkElement).MinWidth)
            {
                adornedElement.Width = finalWidth;
            }
            if (finalHeight <= (this.AdornedElement as FrameworkElement).MaxHeight && finalHeight >= (this.AdornedElement as FrameworkElement).MinHeight)
            {
                adornedElement.Height = finalHeight; 
            }         
            
        }
        #endregion
    }

}

