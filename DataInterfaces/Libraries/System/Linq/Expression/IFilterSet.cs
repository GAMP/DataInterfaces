using System.Collections.Generic;

namespace System.Linq.Expressions
{
    /// <summary>
    /// Filter set implementation interface.
    /// </summary>
    public interface IFilterSet : IList<Filter>
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets amount of records to skip.
        /// </summary>
        int? Skip { get; set; }

        /// <summary>
        /// Gets or sets amount of records to take.
        /// </summary>
        int? Take { get; set; }

        /// <summary>
        /// Gets includes hash set.
        /// </summary>
        ICollection<string> Includes { get; } 

        #endregion
    }
}