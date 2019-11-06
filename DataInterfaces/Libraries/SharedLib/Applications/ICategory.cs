using System;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace SharedLib.Applications
{
    /// <summary>
    /// Category implementation interface.
    /// </summary>
    public interface ICategory
    {
        #region PROPERTIES

        /// <summary>
        /// Gets category id.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Gets category guid.
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Gets category name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets parent category id.
        /// </summary>
        int ParentID { get; set; }

        /// <summary>
        /// Gets if category children present.
        /// </summary>
        bool HasChildren { get; }

        /// <summary>
        /// Gets if child filter is set.
        /// </summary>
        bool HasFilter { get; }

        /// <summary>
        /// Gets current filter.
        /// </summary>
        string Filter { get; }

        /// <summary>
        /// Gets Hierarchical category view.
        /// </summary>
        ListCollectionView HierarchicalView { get; }

        /// <summary>
        /// Gets children.
        /// </summary>
        ObservableCollection<object> Children { get; } 

        #endregion
    }
}
