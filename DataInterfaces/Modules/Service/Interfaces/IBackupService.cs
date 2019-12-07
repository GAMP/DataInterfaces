using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// Represents a type used to take database backups.
    /// </summary>
    public interface IBackupService
    {
        /// <summary>
        /// Returns the directory where the backups are stored.
        /// </summary>
        /// <returns></returns>
        string GetBackupPath();

        /// <summary>
        /// Returns a list of backup files.
        /// </summary>
        /// <returns></returns>
        List<BackupFileInfo> GetBackupFiles();

        /// <summary>
        /// Takes a backup based on configuration.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<BackupResult> BackupAsync(CancellationToken ct);
    }
}