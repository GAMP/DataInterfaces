using System;

namespace SharedLib
{
    /// <summary>
    /// News feed implementation interface.
    /// </summary>
    public interface INewsFeed
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        string Data { get; set; }

        /// <summary>
        /// Gets or sets added date.
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets end date.
        /// </summary>
        DateTime EndDate { get; set; }

        /// <summary>
        /// Gets if media.
        /// </summary>
        bool IsMedia { get; }

        /// <summary>
        /// Gets if syndication source.
        /// </summary>
        bool IsSyndicationSource { get; }

        /// <summary>
        /// Gets or sets start date.
        /// </summary>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets URI.
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets URL.
        /// </summary>
        string Url { get; set; }

        #endregion
    }
}
