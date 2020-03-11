using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Monetary unit entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class MonetaryUnit : ModifiableByUserBase
    {
        #region MonetaryUnit

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [DataMember()]
        [Required()]
        [ProtoMember(1)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets display order.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int DisplayOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if entity is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public bool IsDeleted
        {
            get; set;
        }

        #endregion
        
    }
}
