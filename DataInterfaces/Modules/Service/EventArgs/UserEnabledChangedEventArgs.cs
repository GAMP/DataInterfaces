using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERENABLEDCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserEnabledChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR

        public UserEnabledChangedEventArgs(int userId, bool disabled)
            : base(userId, UserChangeType.Enabled)
        {
            Disabled = disabled;
        }

        public UserEnabledChangedEventArgs(int userId, bool disabled, DateTime? enableDate, DateTime? disabledDate)
         : base(userId, UserChangeType.Enabled)
        {
            Disabled = disabled;
            EnableDate = enableDate;
            DisabledDate = disabledDate;
        }

        #endregion

        #region FIELDS
        [OptionalField(VersionAdded = 1)]
        private DateTime? enableDate;
        [OptionalField(VersionAdded = 1)]
        private DateTime? disabledDate;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if user is disabled.
        /// </summary>
        public bool Disabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets enable date.
        /// </summary>
        public DateTime? EnableDate
        {
            get { return enableDate; }
            protected set { enableDate = value; }
        }

        /// <summary>
        /// Gets disabled date.
        /// </summary>
        public DateTime? DisabledDate
        {
            get { return disabledDate; }
            protected set { disabledDate = value; }
        }

        #endregion
    }
    #endregion
}
