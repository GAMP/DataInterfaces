using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Base entity for Shift and Register entites.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class EntityWithShift : CreatedByBase
    {
        #region EntityWithShift

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int? RegisterId
        {
            get; set;
        }

        #endregion
    }
}
