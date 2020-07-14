using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SharedLib
{
    #region PropertyChangedNotificator
    [Serializable()]
    public class PropertyChangedNotificator : INotifyPropertyChanged
    {
        #region FIELDS
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region FUNCTIONS

        protected void RaisePropertyChanged(string propertyName)
        {
            //Null or empty  string propertyName should be allowed http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged.aspx

            //get handler instance
            var handler = this.PropertyChanged;

            //check if handler exists
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);

                handler(this, args);
            }

            this.OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
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

        #region Fields
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

        #region Fields
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
        /// Gets or sets item container.
        /// </summary>
        [XmlIgnore()]
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
                return Application.Current != null ? Application.Current.Dispatcher : null;
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
}
