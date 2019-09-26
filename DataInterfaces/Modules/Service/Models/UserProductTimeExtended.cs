using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Extended product time dto.
    /// </summary>
    [NotMapped()]
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserProductTimeExtended : UserProductTime
    {
        #region PROPERTIES
        /// <summary>
        /// Descirption.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(1)]
        public string Description
        {
            get; set;
        }
        #endregion
    }
}
