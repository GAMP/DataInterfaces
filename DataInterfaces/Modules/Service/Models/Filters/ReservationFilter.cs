using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Reservation filter.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ReservationFilter : DateRangeFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets deisred reservation id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? Id
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets desired reservation status.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ReservationStatus? Status
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets desired user id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? UserId
        {
            get; set;
        }

        #endregion
    }
}
