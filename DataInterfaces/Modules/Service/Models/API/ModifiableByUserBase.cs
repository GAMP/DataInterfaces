using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ModifiableByUserBase : CreatedByBase
    {
        /// <summary>
        /// Gets or sets modified by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? ModifiedById
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last modified time.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public DateTime? ModifiedTime
        {
            get;
            set;
        }
    }
}
