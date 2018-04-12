using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public interface IClientSwitchInModule
    {
        #region FUNCTIONS

        Task SwitchInAsync(CancellationToken ct);

        Task SwitchOutAsync(CancellationToken ct);
        
        #endregion
    }
}