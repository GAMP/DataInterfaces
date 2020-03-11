using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class EntityBase
    {
        /// <summary>
        /// Gets or sets primary id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int Id
        {
            get;
            set;
        }
    }
}
