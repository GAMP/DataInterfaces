using CoreLib.Diagnostics;
using SharedLib.Dispatcher;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Core process factory interface.
    /// </summary>
    public interface ICoreProcessFactory
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Starts process.
        /// </summary>
        /// <param name="startInfo">Start info.</param>
        /// <param name="dispatcher">Dispatcher instance.</param>
        /// <returns>Started process.</returns>
        ICoreProcess Start(ICoreProcessStartInfo startInfo, IMessageDispatcher dispatcher);

        /// <summary>
        /// Starts process asynchronously.
        /// </summary>
        /// <param name="startInfo">Start info.</param>
        /// <param name="dispatcher">Dispatcher instance.</param>
        /// <returns>Started process.</returns>
        Task<ICoreProcess> StartAsync(ICoreProcessStartInfo startInfo, IMessageDispatcher dispatcher);

        /// <summary>
        /// Creates new startinfo class.
        /// </summary>
        /// <returns>Created startinfo class.</returns>
        ICoreProcessStartInfo CreateStartInfo(); 

        #endregion
    }
}
