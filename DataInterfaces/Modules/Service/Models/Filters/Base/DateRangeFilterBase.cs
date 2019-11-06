using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Record filter base.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public abstract class DateRangeFilterBase : TakeSkipFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets filtered start date.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Start
        {
            get; set;
        }

        /// <summary>
        /// Gets filtered end date.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? End
        {
            get; set;
        }

        #endregion
    }
}
