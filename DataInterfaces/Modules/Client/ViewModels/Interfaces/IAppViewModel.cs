using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLib;

namespace Client.ViewModels
{
    /// <summary>
    /// Client app view model interface.
    /// </summary>
    public interface IAppViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets add date.
        /// </summary>
        DateTime AddDate { get; }

        /// <summary>
        /// Gets app id.
        /// </summary>
        int AppId { get; }

        /// <summary>
        /// Gets category id.
        /// </summary>
        int CategoryId { get; }

        /// <summary>
        /// Gets developer id.
        /// </summary>
        int? DeveloperId { get; }

        /// <summary>
        /// Gets publisher id.
        /// </summary>
        int? PublisherId { get; }

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets executables collection view.
        /// </summary>
        /// <remarks>
        /// The member exposed as IEnumerable for .NET Standard compatibility reasons.
        /// </remarks>
        IEnumerable Executables { get; }

        /// <summary>
        /// Gets executable titles.
        /// </summary>
        IEnumerable<string> ExecutableTitles { get; }

        /// <summary>
        /// Gets executable modes.
        /// </summary>
        IEnumerable<ApplicationModes> ExeModes { get; }

        /// <summary>
        /// Gets app image task.
        /// </summary>
        NotifyTaskCompletion<byte[]> ImageData { get; }

        /// <summary>
        /// Gets rating.
        /// </summary>
        int Rating { get; }

        /// <summary>
        /// Gets release date.
        /// </summary>
        DateTime? ReleaseDate { get; }

        /// <summary>
        /// Gets title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets total executions.
        /// </summary>
        int TotalExecutions { get; }

        /// <summary>
        /// Gets total execution time.
        /// </summary>
        double TotalExecutionTime { get; }

        /// <summary>
        /// Gets total rates.
        /// </summary>
        int TotalRates { get; }

        /// <summary>
        /// Gets current user rating.
        /// </summary>
        int UserRating { get; }

        #endregion
    }
}