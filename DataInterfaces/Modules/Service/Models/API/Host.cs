using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Host entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class Host : ModifiableByUserBase
    {
        #region Host

        /// <summary>
        /// Gets or sets host number.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets host name.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(45)]
        [ProtoMember(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets host group.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int? HostGroupId { get; set; }

        /// <summary>
        /// Gets or sets host state.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public HostState State { get; set; }

        /// <summary>
        /// Gets or sets icon id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int? IconId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if host is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public bool IsDeleted
        {
            get; set;
        }

        #endregion        
    }
}