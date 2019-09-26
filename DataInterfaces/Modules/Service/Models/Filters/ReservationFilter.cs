using ProtoBuf;
using SharedLib;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [ProtoContract()]
    public class ReservationFilter : RecordFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets deisred reservation id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public int? Id
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets desired reservation status.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public ReservationStatus? Status
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets desired user id.
        /// </summary>
        [ProtoMember(3)]
        [DataMember(EmitDefaultValue = false)]
        public int? UserId
        {
            get; set;
        }

        #endregion
    }
}
