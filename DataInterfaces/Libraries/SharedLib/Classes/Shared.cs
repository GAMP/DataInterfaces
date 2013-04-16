using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Reflection;
using System.Runtime.Serialization;
using IntegrationLib;

namespace SharedLib
{
    #region PropertyChangedNotificator
    [Serializable()]
    public class PropertyChangedNotificator : INotifyPropertyChanged
    {
        #region Property Change Events
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyInfo PropInfo = this.GetType().GetProperty(propertyName);
                    if (PropInfo != null)
                        PropertyChanged(this, new PropertyChange(propertyName, PropInfo.GetValue(this, null)));
                }
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
    #endregion

    #region PropertyChange
    [Serializable()]
    public class PropertyChange : PropertyChangedEventArgs
    {
        #region Fileds
        private Object newValue, oldValue;
        #endregion

        #region Constructor

        public PropertyChange(String propertyName, Object NewValue)
            : base(propertyName)
        {
            this.newValue = NewValue;
        }

        public PropertyChange(String propertyName, Object NewValue, Object OldValue)
            : base(propertyName)
        {
            this.newValue = NewValue;
            this.oldValue = OldValue;
        }

        #endregion

        #region Properties

        /// <summary>
        ///Gets the new value of the object.
        /// </summary>
        public Object NewValue
        {
            get { return this.newValue; }
        }

        /// <summary>
        /// Gets the old value of the object.
        /// </summary>
        public Object OldValue
        {
            get { return this.oldValue; }
        }

        #endregion
    }
    #endregion

    #region ItemBase
    /// <summary>
    /// Base class for item classes.
    /// <remarks>
    /// This class provides an data and view model functionality.
    /// </remarks>
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ItemBase : PropertyChangedNotificator, IItemBase
    {
        #region Constructor
        public ItemBase()
        {
        }
        #endregion

        #region Fileds
        private int id;
        #endregion

        #region Properties
        [DataMember(Name = "Id")]
        public virtual int ID
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.RaisePropertyChanged("ID");
            }
        }
        #endregion

        #region ViewModel Code

        #region Fileds
        [NonSerialized()]
        protected bool isSelected = false;
        [NonSerialized()]
        private bool isInitializing = false;
        [NonSerialized()]
        private bool isInitialized = false;
        [NonSerialized()]
        private IItemBase container = null;
        [NonSerialized()]
        private bool isEnabled = true;
        [NonSerialized()]
        private bool isExpanded = false;
        [NonSerialized()]
        private bool isChecked = false;
        [NonSerialized()]
        private bool isFocused = false;
        [NonSerialized()]
        private bool isVirtual;
        [NonSerialized()]
        protected System.Windows.Threading.Dispatcher uiDispatcher;
        #endregion

        #region Properties

        /// <summary>
        /// Checks if element initialization was previously completed.
        /// </summary>
        public bool IsInitialized
        {
            get { return this.isInitialized; }
            set
            {
                this.isInitialized = value;
                this.RaisePropertyChanged("IsInitialized");
            }
        }

        /// <summary>
        /// Gets or sest if object is initializing.
        /// </summary>
        public bool IsInitializing
        {
            get { return this.isInitializing; }
            set
            {
                this.isInitializing = value;
                this.isInitialized = !this.isInitializing;
                this.RaisePropertyChanged("IsInitialized");
                this.RaisePropertyChanged("IsInitializing");

            }
        }

        /// <summary>
        /// Gets or sets if object represents an virtual item.
        /// </summary>
        public virtual bool IsVirtual
        {
            get { return this.isVirtual; }
            set
            {
                this.isVirtual = value;
                this.RaisePropertyChanged("IsVirtual");
            }
        }

        /// <summary>
        /// Gets or Sets items container.
        /// </summary>
        public virtual IItemBase Container
        {
            get { return this.container; }
            set
            {
                this.container = value;
                this.RaisePropertyChanged("Container");
            }
        }

        /// <summary>
        /// Gets or sets if item is enabled.
        /// </summary>
        public virtual bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                this.isEnabled = value;
                this.RaisePropertyChanged("IsEnabled");
            }
        }

        /// <summary>
        /// Gets or sets if item is selected.
        /// </summary>
        public virtual bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets or sets if item is expanded.
        /// </summary>
        public virtual bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                this.isExpanded = value;
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// Gets or sets if item is checked.
        /// </summary>
        public virtual bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked = value;
                this.RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Gets or sets if item is focused.
        /// </summary>
        public virtual bool IsFocused
        {
            get { return this.isFocused; }
            set
            {
                this.isFocused = value;
                this.RaisePropertyChanged("IsFocused");
            }
        }

        /// <summary>
        /// Gets or sets UI Dispatcher foir this item.
        /// </summary>
        public System.Windows.Threading.Dispatcher UIDispatcher
        {
            get
            {
                if (this.uiDispatcher == null)
                {
                    if (Application.Current != null)
                    {
                        this.uiDispatcher = Application.Current.Dispatcher;
                    }
                }
                return this.uiDispatcher;
            }
            set
            {
                this.uiDispatcher = value;
                this.RaisePropertyChanged("UIDispatcher");
            }
        }

        #endregion

        #endregion
    }
    #endregion

    #region AddRemoveBase
    /// <summary>
    /// Generic class for objects that supports addition and items removal.
    /// </summary>
    [Serializable()]
    public class AddRemoveBase : CollectionItemBase
    {
        #region Fileds
        [NonSerialized()]
        private ObservableCollection<object> addedItems;
        [NonSerialized()]
        private ObservableCollection<object> removedItems;
        #endregion

        #region Properties
        /// <summary>
        ///  Gets or sets items that was added to this container.
        /// </summary>
        public ObservableCollection<object> AddedItems
        {
            get
            {
                if (this.addedItems == null)
                {
                    this.addedItems = new ObservableCollection<object>();
                }
                return this.addedItems;
            }
        }
        /// <summary>
        /// Gets or sets items that was removed from this container.
        /// </summary>
        public ObservableCollection<object> RemovedItems
        {
            get
            {
                if (this.removedItems == null)
                {
                    this.removedItems = new ObservableCollection<object>();
                }
                return this.removedItems;
            }
        }
        #endregion

        #region Virtual Methods
        /// <summary>
        /// Assigns and unassigns items parent container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnItemCollectionChnaged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (ItemBase newItem in e.NewItems)
                {
                    //assign a container for the new item
                    newItem.Container = this;
                    if (this.IsInitialized == true)
                    {
                        //add the item to added list
                        this.AddedItems.Add(newItem);
                        //check if item existed and was previously removed (shared objects or undo redo)
                        if (this.RemovedItems.Contains(newItem))
                        {
                            //remove the item from remove list as it was readded
                            this.RemovedItems.Remove(newItem);
                        }
                    }
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (ItemBase newItem in e.OldItems)
                {
                    //unassign the container
                    newItem.Container = null;
                    if (this.IsInitialized == true)
                    {
                        //Remove the item from added items in case the item was previously added. 
                        if (this.AddedItems.Contains(newItem))
                        {
                            this.AddedItems.Remove(newItem);
                        }
                        else
                        {
                            //add the item to removed items
                            //this should only occour when item did not exist in added items list
                            this.RemovedItems.Add(newItem);
                        }
                    }
                }
            }
        }
        #endregion
    }
    #endregion

    #region CollectionItemBase
    /// <summary>
    /// View Model class for representing containers.
    /// </summary>
    [Serializable()]
    public class CollectionItemBase : ItemBase
    {
        #region Fileds
        [NonSerialized()]
        private bool isRoot;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets if the collection has children.
        /// </summary>
        public virtual bool HasChildren
        {
            get { return false; }
        }

        /// <summary>
        /// Gets if the collection is filtered.
        /// </summary>
        public virtual bool HasFilter
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets if the CollectionItemBase represents root.
        /// </summary>
        public virtual bool IsRoot
        {
            get { return this.isRoot; }
            set
            {
                this.isRoot = value;
                this.RaisePropertyChanged("IsRoot");
            }
        }

        #endregion
    }
    #endregion

    #region ItemObject
    /// <summary>
    /// Base class for item objects.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ItemObject : PropertyChangedNotificator
    {
        #region Fields
        private int id;
        #endregion

        #region Properties
        [DataMember()]
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.RaisePropertyChanged("Id");
            }
        }
        #endregion
    }
    #endregion

    #region PropertyChangeNotifier
    public sealed class PropertyChangeNotifier : DependencyObject, IDisposable
    {
        #region Member Variables
        private WeakReference _propertySource;
        #endregion

        #region Constructor
        public PropertyChangeNotifier(DependencyObject propertySource, string path)
            : this(propertySource, new PropertyPath(path))
        {
        }
        public PropertyChangeNotifier(DependencyObject propertySource, DependencyProperty property)
            : this(propertySource, new PropertyPath(property))
        {
        }
        public PropertyChangeNotifier(DependencyObject propertySource, PropertyPath property)
        {
            if (null == propertySource)
                throw new ArgumentNullException("propertySource");
            if (null == property)
                throw new ArgumentNullException("property");
            this._propertySource = new WeakReference(propertySource);
            Binding binding = new Binding();
            binding.Path = property;
            binding.Mode = BindingMode.OneWay;
            binding.Source = propertySource;
            BindingOperations.SetBinding(this, ValueProperty, binding);
        }
        #endregion

        #region PropertySource
        public DependencyObject PropertySource
        {
            get
            {
                try
                {
                    // note, it is possible that accessing the target property
                    // will result in an exception so i’ve wrapped this check
                    // in a try catch
                    return this._propertySource.IsAlive
                    ? this._propertySource.Target as DependencyObject
                    : null;
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region Value
        /// <summary>
        /// Identifies the <see cref=”Value”/> dependency property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value",
        typeof(object), typeof(PropertyChangeNotifier), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            PropertyChangeNotifier notifier = (PropertyChangeNotifier)d;
            if (null != notifier.ValueChanged)
                notifier.ValueChanged(notifier, e);
        }

        /// <summary>
        /// Returns/sets the value of the property
        /// </summary>
        /// <seealso cref=”ValueProperty”/>
        [Description("Returns/sets the value of the property")]
        [Category("Behavior")]
        [Bindable(true)]
        public object Value
        {
            get
            {
                return (object)this.GetValue(PropertyChangeNotifier.ValueProperty);
            }
            set
            {
                this.SetValue(PropertyChangeNotifier.ValueProperty, value);
            }
        }
        #endregion

        #region Events
        public event DependencyPropertyChangedEventHandler ValueChanged;
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            BindingOperations.ClearBinding(this, ValueProperty);
        }
        #endregion
    }
    #endregion

    #region WindowShowParams
    /// <summary>
    /// Window creation and show parameters.
    /// </summary>
    public class WindowShowParams : PropertyChangedNotificator
    {
        #region Constructor

        public WindowShowParams()
        {
            this.StarupLocation = WindowStartupLocation.CenterOwner;
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
            this.AllowClosing = true;
            this.AllowDrag = true;
            this.ShowDialog = true;
            this.Icon = MessageBoxImage.Question;
            this.Buttons = MessageBoxButton.OK;
            this.TopMost = true;
        }

        public WindowShowParams(string title)
            : this()
        {
            this.Title = title;
        }

        public WindowShowParams(string title,
            double width = double.PositiveInfinity,
            double height = double.PositiveInfinity,
            int top = 0, int left = 0)
            : this(title)
        {
            this.Width = width;
            this.Height = height;
            this.Top = top;
            this.Left = left;
        }

        #endregion

        #region Fields
        private double
            maxWidth = double.PositiveInfinity,
            maxHeight = double.PositiveInfinity;
        private NotificationButtons defaultButton = NotificationButtons.Ok;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the windows title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets left position.
        /// </summary>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets top position.
        /// </summary>
        public int Top
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window should be shown as dialog.
        /// </summary>
        public bool ShowDialog
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window should be topmost.
        /// </summary>
        public bool TopMost
        {
            get;
            set;
        }

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

        /// <summary>
        /// Gets or sets window owner.
        /// </summary>
        public IntPtr Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window will be draggable.
        /// </summary>
        public bool AllowDrag
        {
            get;
            set;
        }

        public bool NoButtons
        {
            get;
            set;
        }

        public bool AllowClosing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets startup location.
        /// </summary>
        public WindowStartupLocation StarupLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets size to content type.
        /// </summary>
        public SizeToContent SizeToContent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Messagebox buttons type.
        /// </summary>
        public MessageBoxButton Buttons
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Messagebox icon image type.
        /// </summary>
        public MessageBoxImage Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets keyboard default button.
        /// </summary>
        public NotificationButtons DefaultButton
        {
            get { return this.defaultButton; }
            set
            {
                this.defaultButton = value;
                this.RaisePropertyChanged("DefaultButton");
            }
        }

        /// <summary>
        /// Gets or sets if window should be show activated.
        /// </summary>
        public bool ShowActivated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets window maximum width.
        /// </summary>
        public double MaxWidth
        {
            get { return this.maxWidth; }
            set
            {
                this.maxWidth = value;
                this.RaisePropertyChanged("MaxWidth");
            }
        }

        /// <summary>
        /// Gets or sets window maximum height.
        /// </summary>
        public double MaxHeight
        {
            get { return this.maxHeight; }
            set
            {
                this.maxHeight = value;
                this.RaisePropertyChanged("MaxHeight");
            }
        }

        #endregion
    }
    #endregion
}
