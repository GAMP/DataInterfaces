using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace SharedLib
{
    /// <summary>
    /// Property change notifier class.
    /// </summary>
    public sealed class PropertyChangeNotifier : DependencyObject, IDisposable
    {    
        #region CONSTRUCTOR
        
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertySource">Property source object.</param>
        /// <param name="path">Property path.</param>
        public PropertyChangeNotifier(DependencyObject propertySource, string path)
            : this(propertySource, new PropertyPath(path))
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertySource">>Property source object.</param>
        /// <param name="property">Dependency property.</param>
        public PropertyChangeNotifier(DependencyObject propertySource, DependencyProperty property)
            : this(propertySource, new PropertyPath(property))
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertySource">>Property source object.</param>
        /// <param name="property">Property path.</param>
        public PropertyChangeNotifier(DependencyObject propertySource, PropertyPath property)
        {
            if (null == propertySource)
                throw new ArgumentNullException("propertySource");
            if (null == property)
                throw new ArgumentNullException("property");
            this._propertySource = new WeakReference(propertySource);
            Binding binding = new Binding()
            {
                Path = property,
                Mode = BindingMode.OneWay,
                Source = propertySource
            };
            BindingOperations.SetBinding(this, ValueProperty, binding);
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// Occurs on value change.
        /// </summary>
        public event DependencyPropertyChangedEventHandler ValueChanged;

        #endregion

        #region FIELDS
        private WeakReference _propertySource;
        #endregion        

        #region PROPERTYSOURCE

        /// <summary>
        /// Gets property source object.
        /// </summary>
        public DependencyObject PropertySource
        {
            get
            {
                try
                {
                    // note, it is possible that accessing the target property
                    // will result in an exception so i’ve wrapped this check
                    // in a try catch
                    return _propertySource.IsAlive
                    ? _propertySource.Target as DependencyObject
                    : null;
                }
                catch
                {
                    return null;
                }
            }
        }

        #endregion

        #region VALUE

        /// <summary>
        /// Identifies the <see cref="Value"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value",
            typeof(object), typeof(PropertyChangeNotifier), 
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PropertyChangeNotifier notifier = (PropertyChangeNotifier)d;
            notifier.ValueChanged?.Invoke(notifier, e);
        }

        /// <summary>
        /// Returns/sets the value of the property
        /// </summary>
        /// <seealso cref="ValueProperty"/>
        [Description("Returns/sets the value of the property")]
        [Category("Behavior")]
        [Bindable(true)]
        public object Value
        {
            get
            {
                return GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        #endregion        

        #region IDisposable Members

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            BindingOperations.ClearBinding(this, ValueProperty);
        }

        #endregion
    }
}
