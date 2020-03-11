using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Attribute entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class Attribute : ModifiableByUserBase
    {
        #region Attribute

        /// <summary>
        /// Gets or sets attribute name.
        /// </summary>
        [Required()]
        [StringLength(45)]
        [DataMember()]
        [ProtoMember(1)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets friendly name.
        /// </summary>
        [StringLength(45)]
        [DataMember()]
        [ProtoMember(2)]
        public string FriendlyName
        {
            get; set;
        }

        #endregion

    }
}
