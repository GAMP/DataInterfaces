using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User enabled event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserEnabledChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="disabled">Indicates if user is disabled.</param>
        public UserEnabledChangedEventArgs(int userId, bool disabled)
            : base(userId, UserChangeType.Enabled)
        {
            Disabled = disabled;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="disabled">Indicates if user is disabled.</param>
        /// <param name="enableDate">Enable date.</param>
        /// <param name="disabledDate">Disable date.</param>
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
        [DataMember()]
        public bool Disabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets enable date.
        /// </summary>
        [DataMember()]
        public DateTime? EnableDate
        {
            get { return enableDate; }
            protected set { enableDate = value; }
        }

        /// <summary>
        /// Gets disabled date.
        /// </summary>
        [DataMember()]
        public DateTime? DisabledDate
        {
            get { return disabledDate; }
            protected set { disabledDate = value; }
        }

        #endregion
    }
}
