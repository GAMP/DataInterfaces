using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region APPRATEDEVENTARGS
    [DataContract()]
    [Serializable()]
    public class AppRatedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public AppRatedEventArgs(int userId, int appId, int userRating, int appRating, int count) : base(userId)
        {
            this.AppId = appId;
            this.UserRating = userRating;
            this.AppRating = appRating;
            this.RatesCount = count;
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
        /// Gets total ratings count.
        /// </summary>
        [DataMember()]
        public int RatesCount
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion
}
