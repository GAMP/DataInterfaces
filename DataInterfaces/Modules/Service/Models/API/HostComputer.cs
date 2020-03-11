using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Host computer entity.
    /// </summary>
    public class HostComputer : Host
    {
        #region HostComputer

        /// <summary>
        /// Gets or sets hostname.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(255)]
        [ProtoMember(1)]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets mac address.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(255)]
        [ProtoMember(2)]
        public string MACAddress { get; set; }

        #endregion

    }
}
