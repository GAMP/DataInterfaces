using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Host group entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class HostGroup : ModifiableByUserBase
    {
        #region HostGroup

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        [Required()]
        [StringLength(45)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets skin name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        [StringLength(255)]
        public string SkinName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if shell is enabled.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public HostGroupOptionType Options
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app profile id.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int? AppGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int? SecurityProfileId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets default guest group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int? DefaultGuestGroupId
        {
            get; set;
        }

        #endregion

    }
}
