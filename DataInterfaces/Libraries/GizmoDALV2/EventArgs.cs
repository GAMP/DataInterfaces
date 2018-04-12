using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    #region ENTITYEVENTARGS
    [Serializable()]
    [DataContract()]
    public class EntityEventArgs<T> : EventArgs, IEntityEventArgs
    {
        #region CONSTRUCTOR

        public EntityEventArgs(EntityEventType type, T addedItem, T removedItem)
            : this(type)
        {
            if (addedItem != null)
                this.AddedItems = new List<T>() { addedItem };

            if (removedItem != null)
                this.RemovedItems = new List<T>() { removedItem };            
        }

        public EntityEventArgs(EntityEventType type, IEnumerable<T> addedItems, IEnumerable<T> removedItems)
            : this(type)
        {
            this.Type = type;

            if (addedItems != null)
                this.AddedItems = new List<T>(addedItems);

            if (removedItems != null)
                this.RemovedItems = new List<T>(removedItems);
        }

        public EntityEventArgs(EntityEventType type)
        {
            this.Type = type;
        }

        public EntityEventArgs(EntityEventType type, object added,object removed):this(type, (T)added, (T)removed)
        {
            this.Type = type;
        }

        public EntityEventArgs(EntityEventType type, IEnumerable<object> added, IEnumerable<object> removed)
            : this(type, added.Cast<T>(), removed.Cast<T>())
        {
            this.Type = type;
        }

        #endregion

        #region FIELDS
        private IEnumerable<T> addedItems, removedItems;
        #endregion

        #region PROPERTIES

        #region INTERFACE

        IEnumerable<object> IEntityEventArgs.RemovedItems
        {
            get { return this.RemovedItems.Cast<object>(); }
        }

        IEnumerable<object> IEntityEventArgs.AddedItems
        {
            get { return this.AddedItems.Cast<object>(); }
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
    #endregion


}
