using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Log change event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class LogChangeEventArgs : EventArgs
    {
    }
}
