using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    /// <summary>
    /// Entity event arguments.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    [Serializable()]
    [DataContract()]
    public class EntityEventArgs<T> : EventArgs, IEntityEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Entity type.</param>
        /// <param name="addedItem">Added items.</param>
        /// <param name="removedItem">Removed items.</param>
        public EntityEventArgs(EntityEventType type, T addedItem, T removedItem)
            : this(type)
        {
            if (addedItem != null)
                AddedItems = new List<T>() { addedItem };

            if (removedItem != null)
                RemovedItems = new List<T>() { removedItem };            
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Entity type.</param>
        /// <param name="addedItems">Added items.</param>
        /// <param name="removedItems">Removed items.</param>
        public EntityEventArgs(EntityEventType type, IEnumerable<T> addedItems, IEnumerable<T> removedItems)
            : this(type)
        {
            Type = type;

            if (addedItems != null)
                AddedItems = new List<T>(addedItems);

            if (removedItems != null)
                RemovedItems = new List<T>(removedItems);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Entity type.</param>
        public EntityEventArgs(EntityEventType type)
        {
            Type = type;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Entity type.</param>
        /// <param name="added">Added items.</param>
        /// <param name="removed">Removed items.</param>
        public EntityEventArgs(EntityEventType type, object added,object removed):this(type, (T)added, (T)removed)
        {
            Type = type;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Entity type.</param>
        /// <param name="added">Added items.</param>
        /// <param name="removed">Removed items.</param>
        public EntityEventArgs(EntityEventType type, IEnumerable<object> added, IEnumerable<object> removed)
            : this(type, added.Cast<T>(), removed.Cast<T>())
        {
            Type = type;
        }

        #endregion

        #region FIELDS
        private IEnumerable<T> addedItems, removedItems;
        #endregion

        #region PROPERTIES

        #region INTERFACE

        IEnumerable<object> IEntityEventArgs.RemovedItems
        {
            get { return RemovedItems.Cast<object>(); }
        }

        IEnumerable<object> IEntityEventArgs.AddedItems
        {
            get { return AddedItems.Cast<object>(); }
        }

        IEnumerable<object> IEntityEventArgs.AllItems
        {
            get { return AllItems.Cast<object>(); }
        }

        #endregion

        /// <summary>
        /// Gets removed items.
        /// </summary>
        [DataMember]
        public IEnumerable<T> RemovedItems
        {
            get
            {
                if (this.removedItems == null)
                    this.removedItems = new List<T>();
                return this.removedItems;
            }
            protected set { this.removedItems = value; }
        }

        /// <summary>
        /// Gets added items.
        /// </summary>
        [DataMember()]
        public IEnumerable<T> AddedItems
        {
            get
            {
                if (this.addedItems == null)
                    this.addedItems = new List<T>();
                return this.addedItems;
            }
            protected set { this.addedItems = value; }
        }

        [IgnoreDataMember()]
        public IEnumerable<T> AllItems
        {
            get { return AddedItems.Union(RemovedItems); }
        }

        /// <summary>
        /// Gets event type.
        /// </summary>
        [DataMember()]
        public EntityEventType Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        [DataMember()]
        public Type EntityType
        {
            get
            {
                return typeof(T);
            }
        }

        #endregion
    }
}
