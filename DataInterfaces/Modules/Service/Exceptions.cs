using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServerService
{
    #region MaximumConnectionsException
    /// <summary>
    /// This exception is thrown when maximum client connections reached.
    /// </summary>
    [Serializable]
    public class MaximumConnectionsException : Exception
    {
        #region Constructor
        public MaximumConnectionsException(string message)
            : base(message)
        { }
        public MaximumConnectionsException() : base() { }
        public MaximumConnectionsException(string message, System.Exception inner) : base(message, inner) { }
        protected MaximumConnectionsException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { } 
        #endregion
    }
    #endregion
}
