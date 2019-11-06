using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// App rated event args.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class AppRatedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="appId">App id.</param>
        /// <param name="userRating">User rating value.</param>
        /// <param name="appRating">Global rating value.</param>
        /// <param name="count">Total rates count.</param>
        public AppRatedEventArgs(int userId, int appId, int userRating, int appRating, int count) : base(userId)
        {
            AppId = appId;
            UserRating = userRating;
            AppRating = appRating;
            RatesCount = count;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets rated app id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets global average rating value.
        /// </summary>
        [DataMember()]
        public int AppRating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets user rating value.
        /// </summary>
        [DataMember()]
        public int UserRating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total rates count.
        /// </summary>
        [DataMember()]
        public int RatesCount
        {
            get;
            private set;
        }

        #endregion
    }
}
