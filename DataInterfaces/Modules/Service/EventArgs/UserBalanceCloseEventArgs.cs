using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERBALANCECLOSEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserBalanceCloseEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserBalanceCloseEventArgs(int userId) : base(userId)
        { }
        #endregion
    }
    #endregion
}
