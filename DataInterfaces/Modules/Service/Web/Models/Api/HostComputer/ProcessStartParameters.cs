using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Process start parameters model.
    /// </summary>
    [DataContract()]
    public class ProcessStartParameters
    {
        #region PROPERTIES

        /// <summary>
        /// Process file name.
        /// </summary>
        [Required()]
        [DataMember(Order = 0)]
        public string FileName { get; set; }

        /// <summary>
        /// Process start arguments.
        /// </summary>
        [DataMember(Order = 1)]
        public string Arguments { get; set; }

        /// <summary>
        /// Process working directory.
        /// </summary>
        [DataMember(Order = 2)]
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Indicates whether no process window should be created.
        /// </summary>
        [DataMember(Order = 3)]
        public bool CreateNoWindow { get; set; }

        /// <summary>
        /// Indicates whether process should be shell executed.
        /// </summary>
        [DataMember(Order = 4)]
        public bool UseShellExecute { get; set; }

        /// <summary>
        /// Optional password.
        /// </summary>
        [DataMember(Order = 5)]
        public string Password { get; set; }

        /// <summary>
        /// Optional user name.
        /// </summary>
        [DataMember(Order = 6)]
        public string Username { get; set; }

        #endregion
    }
}
