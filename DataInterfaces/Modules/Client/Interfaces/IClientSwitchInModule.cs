using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Client module interface with siwtch in/out support.
    /// </summary>
    public interface IClientSwitchInModule
    {
        #region FUNCTIONS

        /// <summary>
        /// Called when module is being switched in.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task SwitchInAsync(CancellationToken ct);

        /// <summary>
        /// Called when module is being switched out.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task SwitchOutAsync(CancellationToken ct);
        
        #endregion
    }
}