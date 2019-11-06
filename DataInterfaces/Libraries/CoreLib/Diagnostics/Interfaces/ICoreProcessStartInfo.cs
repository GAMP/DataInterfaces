using System.Diagnostics;

namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Core process start info interface.
    /// </summary>
    public interface ICoreProcessStartInfo
    {
        #region PROPERTIES
       
        /// <summary>
        /// Gets or sets process creation arguments.
        /// </summary>
        string Arguments { get; set; }

        /// <summary>
        /// Gets or sets if no process window should be created.
        /// </summary>
        bool CreateNoWindow { get; set; }

        /// <summary>
        /// Gets or sets file name.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets if we should wait for process termination.
        /// </summary>
        bool WaitForTermination { get; set; }

        /// <summary>
        /// Gets or sets process termination wait timeout.
        /// </summary>
        int WaitTimeout { get; set; }

        /// <summary>
        /// Gets or sets working directory of created process.
        /// </summary>
        string WorkingDirectory { get; set; } 

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Converts to process start info.
        /// </summary>
        /// <returns>ProcessStartInfo class.</returns>
        ProcessStartInfo ToStartInfo(); 

        #endregion
    }
}
