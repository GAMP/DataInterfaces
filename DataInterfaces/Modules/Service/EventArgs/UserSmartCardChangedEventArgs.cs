using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERSMARTCARDCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserSmartCardChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserSmartCardChangedEventArgs(int userId, string smartCardUID)
            : base(userId, UserChangeType.SmartCardUID)
        {
            SmartCardUID = smartCardUID;
        }
        #endregion

        #region PROPERTIES
        public string SmartCardUID
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
