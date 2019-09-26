using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    [ProtoInclude(500, typeof(ReservationFilter))]
    public abstract class RecordFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets filtered start date.
        /// </summary>
        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Start
        {
            get; set;
        }

        /// <summary>
        /// Gets filtered end date.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public DateTime? End
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets amount of records to take.
        /// </summary>
        [ProtoMember(3)]
        [DataMember(EmitDefaultValue = false)]
        public int? Take
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets amount of records to skip.
        /// </summary>
        [ProtoMember(4)]
        [DataMember(EmitDefaultValue = false)]
        public int? Skip
        {
            get; set;
        } 

        #endregion
    }
}
