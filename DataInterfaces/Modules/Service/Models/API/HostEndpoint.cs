using ProtoBuf;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DefaultValue(1)]
        [Range(1,int.MaxValue)]
        public int MaximumUsers
        {
            get;
            set;
        }

        #endregion
    }
}
