using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Service network stats.
    /// </summary>
    [DataContract()]
    public class ServiceNetworkStats
    {
        #region PROPERTIES

        /// <summary>
        /// Total data sent.
        /// </summary>
        [DataMember()]
        public long DataSent
        {
            get; set;
        }
        
        /// <summary>
        /// Total data received.
        /// </summary>
        [DataMember()]
        public long DataReceived
        {
            get; set;
        }

        /// <summary>
        /// Total number for connected clients.
        /// </summary>
        [DataMember()]
        public int Clients
        {
            get; set;
        }

        /// <summary>
        /// Total number of connected managers.
        /// </summary>
        [DataMember()]
        public int Managers
        {
            get; set;
        }

        #endregion
    }
}
