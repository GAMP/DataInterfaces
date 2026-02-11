using SharedLib;
using System;

namespace ServerService
{
    /// <summary>
    /// User enabled event args.
    /// </summary>
    public sealed class UserEnabledChangedEventArgs : UserProfileChangeEventArgs
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
            _enableDate = enableDate;
            _disabledDate = disabledDate;
        }

        #endregion

        #region FIELDS
        private readonly DateTime? _enableDate;
        private readonly DateTime? _disabledDate;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if user is disabled.
        /// </summary>
        public bool Disabled
        {
            get;
        }

        /// <summary>
        /// Gets enable date.
        /// </summary>
        public DateTime? EnableDate
        {
            get { return _enableDate; }
        }

        /// <summary>
        /// Gets disabled date.
        /// </summary>
        public DateTime? DisabledDate
        {
            get { return _disabledDate; }
        }

        #endregion
    }
}
