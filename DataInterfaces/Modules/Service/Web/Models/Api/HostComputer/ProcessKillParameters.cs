using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Process kill parameters model.
    /// </summary>
    [DataContract()]
    public class ProcessKillParameters
    {
        #region PROPERTIES

        /// <summary>
        /// Module path.
        /// </summary>
        /// <example>
        /// c:\windows\cmd.exe
        /// </example>
        [DataMember()]
        public string ModulePath { get; set; }

        /// <summary>
        /// Process id.
        /// </summary>
        [DataMember()]
        public int? ProcessId { get; set; }

        /// <summary>
        /// Process name.
        /// </summary>
        /// <remarks>
        /// This option only has effect if process id is not set.
        /// </remarks>
        [DataMember()]
        public string ProcessName { get; set; }

        /// <summary>
        /// Indicates if recursive children termination should be done.
        /// </summary>
        /// <remarks>
        /// This option will only be used if tree termination is enabled.
        /// </remarks>
        [DataMember()]
        public bool Recurse { get; set; }

        /// <summary>
        /// Indicates if module path should be respected when terminating the process.
        /// </summary>
        [DataMember()]
        public bool RespectPath { get; set; }

        /// <summary>
        /// Indicates whether child process termination should be done.
        /// </summary>
        [DataMember()]
        public bool Tree { get; set; } 

        #endregion
    }
}
