using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Host endpoint entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class HostEndpoint : Host
    {
        #region HostEndpoint

        /// <summary>
        /// Gets or sets maximum users.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int MaximumUsers
        {
            get;
            set;
        }

        #endregion
    }
}
