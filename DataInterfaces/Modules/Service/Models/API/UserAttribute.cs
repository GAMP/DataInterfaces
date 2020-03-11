using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User attribute entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserAttribute : ModifiableByUserBase
    {
        #region UserAttribute

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets attribute id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int AttributeId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets attribute value.
        /// </summary>
        [StringLength(255)]
        [DataMember()]
        [ProtoMember(3)]
        public string Value
        {
            get; set;
        }

        #endregion
        
    }
}
