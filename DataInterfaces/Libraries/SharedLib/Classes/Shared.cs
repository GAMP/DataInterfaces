using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SharedLib
{
    #region ItemBaseWithDispatcher
    public abstract class ItemBaseWithDispatcher : ItemBase
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets UI Dispatcher foir this item.
        /// </summary>
        public System.Windows.Threading.Dispatcher UIDispatcher
        {
            get
            {
                return Application.Current?.Dispatcher;
            }
        }
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
    public class CollectionItemBase : ItemBaseWithDispatcher
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
}
