using System;
using System.Collections.Generic;

namespace GizmoDALV2
{
    /// <summary>
    /// Entity event arguments interface.
    /// </summary>
    public interface IEntityEventArgs
    {
        #region PROPERTIES

        /// <summary>
        /// Event type.
        /// </summary>
        EntityEventType Type
        {
            get;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        Type EntityType
        {
            get;
        }

        /// <summary>
        /// Gets added items.
        /// </summary>
        IEnumerable<object> AddedItems
        {
            get;
        }

        /// <summary>
        /// Gets removed items.
        /// </summary>
        IEnumerable<object> RemovedItems
        {
            get;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        IEnumerable<object> AllItems { get; }

        #endregion
    }
}
