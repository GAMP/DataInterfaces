using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User smart card change event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserSmartCardChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="smartCardUID">Smart card UID.</param>
        public UserSmartCardChangedEventArgs(int userId, string smartCardUID)
            : base(userId, UserChangeType.SmartCardUID)
        {
            SmartCardUID = smartCardUID;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets new smart card uid.
        /// </summary>
        public string SmartCardUID
        {
            get;
            protected set;
        }

        #endregion
    }
}
