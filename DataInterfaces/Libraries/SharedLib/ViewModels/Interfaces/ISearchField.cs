using System.Collections.Generic;

namespace SharedLib.ViewModels
{
    #region ISearchField
    /// <summary>
    /// Search field interface.
    /// </summary>
    public interface ISearchField
    {
        #region PROPERTIES

        /// <summary>
        /// Gets display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Gets or sets if valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Gets if has value.
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Gets target properties.
        /// </summary>
        IEnumerable<string> TargetProperties { get; }

        #endregion
    }
    #endregion
}
