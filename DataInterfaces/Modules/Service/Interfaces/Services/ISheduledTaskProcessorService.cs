using ServerService.Reporting;
using System.Threading;
using System.Threading.Tasks;

namespace ServerService.Services
{
    /// <summary>
    /// Scheduled task processor service interface.
    /// </summary>
    public interface ISheduledTaskProcessorService
    {
        /// <summary>
        /// Loads active scheduled tasks from configuration.
        /// </summary>
        /// <returns></returns>
        Task LoadAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes any scheduled tasks with NextExecution is equal current DateTime.
        /// </summary>
        /// <returns></returns>
        Task ProcessScheduledTasksAsync(CancellationToken cancellationToken);
    }
}