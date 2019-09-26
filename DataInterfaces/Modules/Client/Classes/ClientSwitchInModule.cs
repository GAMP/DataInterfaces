using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Module supporting switching in and out.
    /// </summary>
    public abstract class ClientSwitchInModule : ClientModuleBase, IClientSwitchInModule
    {
        #region FUNCTIONS

        /// <summary>
        /// Called once we switch to this module.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        public virtual Task SwitchInAsync(CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called once we switching out of this module.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        public virtual Task SwitchOutAsync(CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        #endregion
    } 
}
