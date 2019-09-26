using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region LOGCHANGEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class LogChangeEventArgs : EventArgs
    {
    }
    #endregion    
}
