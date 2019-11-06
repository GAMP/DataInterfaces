using ServerService.Reporting;
using System.Threading.Tasks;

namespace ServerService.Services
{
    /// <summary>
    /// Scheduled tasks processor service interface.
    /// </summary>
    public interface IReportMailTaskProcessorService
    {
        /// <summary>
        /// Loads active scheduled tasks from configuration.
        /// </summary>
        /// <returns></returns>
        void Load();

        /// <summary>
        /// Executes any scheduled tasks with NextExecution is equal current DateTime.
        /// </summary>
        /// <returns></returns>
        Task ProcessScheduledTasksAsync();
    }
}