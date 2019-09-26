using SharedLib.Applications;
using System;

namespace Client
{
    [Serializable()]
    public class ApplicationRateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ApplicationRateEventArgs(int appId, IRating overallRating, IRating userRating)
        {
            if (overallRating == null)
                throw new ArgumentNullException("overallRating");

            if (userRating == null)
                throw new ArgumentNullException("userRating");

            ApplicationId = appId;
            OverallRating = overallRating;
            UserRating = userRating;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets rated application id.
        /// </summary>
        public int ApplicationId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets application overall rating.
        /// </summary>
        public IRating OverallRating
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets application user rating.
        /// </summary>
        public IRating UserRating
        {
            get;
            protected set;
        }

        #endregion
    }
}
