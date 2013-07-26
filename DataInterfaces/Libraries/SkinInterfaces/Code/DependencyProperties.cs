using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SkinInterfaces
{
    #region DependencyPropertyClassBase
    public class DependencyPropertyClassBase
    {
        #region CHANGE EVENTS
        public static event PropertyChangedCallback DependencyPropertyChanged;
        #endregion

        #region PROPERTYCHANGED EVENTS
        /// <summary>
        /// Genereic property change handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>This subs raises DependencyPropertyChanged that notifies all the subscribers of property change event.</remarks>
        public static void PropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (DependencyPropertyChanged != null)
                    DependencyPropertyChanged(sender, e);
            }
            catch
            {
                //Log errors that occour inside the event handler
            }
        }
        #endregion
    }
    #endregion

    #region ExternalProperties
    public class ExternalProperties : DependencyPropertyClassBase
    {
        #region CUSTOM PROPERTIES

        public static readonly DependencyProperty AllowZindexProperty =
            DependencyProperty.Register("AllowZindex",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty AllowDragProperty =
            DependencyProperty.Register("AllowDrag",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty AllowResizeProperty =
            DependencyProperty.Register("AllowResize",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty TopMostProperty =
            DependencyProperty.Register("TopMost",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false));

        public static readonly DependencyProperty VisualStateProperty =
            DependencyProperty.Register("VisualState",
            typeof(ElementVisualState), typeof(UserControl),
            new PropertyMetadata(ElementVisualState.Normal, PropertyChangedHandler));

        public static readonly DependencyProperty SupportedVisualStatesProperty =
            DependencyProperty.Register("SupportedVisualStates",
            typeof(ElementVisualState), typeof(UserControl),
            new PropertyMetadata(ElementVisualState.Normal, PropertyChangedHandler));

        public static readonly DependencyProperty IsMaximizedProperty =
            DependencyProperty.Register("IsMaximized",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static DependencyProperty GUIDProperty =
            DependencyProperty.Register("GUID",
            typeof(String),
            typeof(UserControl),
            new PropertyMetadata(String.Empty, PropertyChangedHandler));

        public static DependencyProperty IsAdornedProperty =
            DependencyProperty.Register("IsAdorned",
            typeof(bool),
            typeof(UIElement),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static DependencyProperty AllowSendToBackgroundProperty =
            DependencyProperty.Register("AllowSendToBackground",
            typeof(bool), typeof(UIElement),
            new PropertyMetadata(true, PropertyChangedHandler));

        public static DependencyProperty IsBackgroundProperty =
            DependencyProperty.Register("IsBackground",
            typeof(bool),
            typeof(UIElement),
            new PropertyMetadata(false, PropertyChangedHandler));

        #endregion
    }
    #endregion

    #region InternalProperties
    public class InternalProperties : DependencyPropertyClassBase
    {
        #region CUSTOM PROPERTIES
        public static readonly DependencyProperty RestoreVisualsProperty =
            DependencyProperty.Register("RestoreVisuals",
            typeof(RestoreVisuals), typeof(UserControl),
            new PropertyMetadata(null, PropertyChangedHandler));

        public static readonly DependencyProperty IsDragEnabledProperty =
            DependencyProperty.Register("IsDragEnabled",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty IsResizeEnabledProperty =
            DependencyProperty.Register("IsResizeEnabled",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty IsZindexEnabledProperty =
            DependencyProperty.Register("IsZindexEnabled", typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty IsActiveElementProperty =
            DependencyProperty.Register("IsActiveElement",
            typeof(bool), typeof(UserControl),
            new PropertyMetadata(false, PropertyChangedHandler));

        public static readonly DependencyProperty UIComponentProperty =
           DependencyProperty.Register("UIComponent",
           typeof(Object), typeof(UserControl),
        new PropertyMetadata(null, PropertyChangedHandler));

        #endregion
    }
    #endregion
}
