using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// App stats event args.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class AppStatEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="appId">App id.</param>
        /// <param name="appExeId">App exe id.</param>
        /// <param name="totalAppTime">Total app time.</param>
        /// <param name="totalAppExecutions">Total app executions.</param>
        /// <param name="totalAppExeTime">Total app exe time.</param>
        /// <param name="totalAppExeExecutions">Total app exe executions.</param>
        /// <param name="totalAppExeUserTime">Total app exe user time.</param>
        /// <param name="totalAppExeUserExectutions">Total app exe user executions.</param>
        public AppStatEventArgs(int userId,
            int appId,
            int appExeId,
            double totalAppTime,
            int totalAppExecutions,
            double totalAppExeTime,
            int totalAppExeExecutions,
            double totalAppExeUserTime,
            int totalAppExeUserExectutions) : base(userId)
        {
            AppId = appId;
            AppExeId = appExeId;

            TotalAppTime = totalAppTime;
            TotalAppExecutions = totalAppExecutions;

            TotalAppExeTime = totalAppExeTime;
            TotalAppExeExecutions = totalAppExeExecutions;

            TotalAppExeUserTime = totalAppExeUserTime;
            TotalAppExeUserExecutions = totalAppExeUserExectutions;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets app id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets app exe id.
        /// </summary>
        [DataMember()]
        public int AppExeId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total app time.
        /// </summary>
        [DataMember()]
        public double TotalAppTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total app executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExecutions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total executable time.
        /// </summary>
        [DataMember()]
        public double TotalAppExeTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Get total executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExeExecutions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total executable user time.
        /// </summary>
        [DataMember()]
        public double TotalAppExeUserTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total user executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExeUserExecutions
        {
            get;
            private set;
        }

        #endregion
    }
}
