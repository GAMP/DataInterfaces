using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CyClone.Core
{
    /// <summary>
    /// Class representing mapping changes event arguments.
    /// </summary>
    [Serializable()]
    public class MappingsEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="added">Added.</param>
        /// <param name="removed">Removed.</param>
        public MappingsEventArgs(NotifyCollectionChangedAction action,
           List<IMappingsConfiguration> added,
           List<IMappingsConfiguration> removed)
        {
            Action = action;
            AddedItems = added;
            RemovedItems = removed;
        }
        #endregion

        #region FIELDS
        private List<IMappingsConfiguration>
            addedItems,
            removedItems;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets change action.
        /// </summary>
        public NotifyCollectionChangedAction Action
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the added items.
        /// </summary>
        public List<IMappingsConfiguration> AddedItems
        {
            get
            {
                if (addedItems == null)
                    addedItems = new List<IMappingsConfiguration>();
                return addedItems;
            }
            protected set
            {
                addedItems = value;
            }
        }

        /// <summary>
        /// Gets removed items.
        /// </summary>
        public List<IMappingsConfiguration> RemovedItems
        {
            get
            {
                if (removedItems == null)
                    removedItems = new List<IMappingsConfiguration>();
                return removedItems;
            }
            protected set { removedItems = value; }
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Change Action {0} Added Items {1} Removed Items {2}", Action, AddedItems.Count, RemovedItems.Count);
        }
        #endregion
    }
}
