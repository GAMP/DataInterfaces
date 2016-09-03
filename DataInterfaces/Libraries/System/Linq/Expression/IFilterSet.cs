using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public interface IFilterSet
    {
        /// <summary>
        /// Gets or sets amount of records to skip.
        /// </summary>
        int? Skip { get; set; }

        /// <summary>
        /// Gets or sets ammount of records to take.
        /// </summary>
        int? Take { get; set; }

        /// <summary>
        /// Gets includes hash set.
        /// </summary>
        IEnumerable<string> Includes { get; }
    }
}