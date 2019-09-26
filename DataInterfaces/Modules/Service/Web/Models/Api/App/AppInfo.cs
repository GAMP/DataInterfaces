using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Application info.
    /// </summary>
    [DataContract()]
    public class AppInfo
    {
        /// <summary>
        /// Application id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get; set;
        }

        /// <summary>
        /// Application title.
        /// </summary>
        [DataMember()]
        public string Title
        {
            get; set;
        }

        /// <summary>
        /// Application description.
        /// </summary>
        [DataMember()]
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// Application rating.
        /// </summary>
        [DataMember()]
        public int Rating
        {
            get; set;
        }

        /// <summary>
        /// Ratings count.
        /// </summary>
        [DataMember()]
        public int RatingsCount
        {
            get; set;
        }

        /// <summary>
        /// Total executions.
        /// </summary>
        [DataMember()]
        public int TotalExecutions
        {
            get; set;
        }

        /// <summary>
        /// Total execution seconds.
        /// </summary>
        [DataMember()]
        public double TotalExecutionSeconds
        {
            get; set;
        }

        /// <summary>
        /// Total execution minutes.
        /// </summary>
        [DataMember()]
        public double TotalExecutionMinutes
        {
            get { return TimeSpan.FromSeconds(TotalExecutionSeconds).TotalMinutes; }
        }

        /// <summary>
        /// Total execution hours.
        /// </summary>
        [DataMember()]
        public double TotalExecutionHours
        {
            get { return TimeSpan.FromSeconds(TotalExecutionSeconds).TotalHours; }
        }
    }
}
