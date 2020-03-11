using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User group host disallowed entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserGroupHostDisallowed : ModifiableByUserBase
    {
        #region UserGroupHostDisallowed

        /// <summary>
        /// Gets or sets user group.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets host group.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int HostGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets disallowed value.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public bool IsDisallowed
        {
            get; set;
        }

        #endregion

    }
}
