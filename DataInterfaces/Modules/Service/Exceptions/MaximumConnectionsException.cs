using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region MAXIMUMCONNECTIONSEXCEPTION
    /// <summary>
    /// This exception is thrown when maximum client connections reached.
    /// </summary>
    [Serializable]
    [DataContract()]
    public class MaximumConnectionsException : Exception
    {
        #region CONSTRUCTOR

        public MaximumConnectionsException(string message)
            : base(message)
        { }

        public MaximumConnectionsException() : base() { }

        public MaximumConnectionsException(string message, Exception inner) : base(message, inner) { }

        protected MaximumConnectionsException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
        
        #endregion
    }
    #endregion
}
