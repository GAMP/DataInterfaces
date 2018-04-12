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
    [DataContract()]
    public class MaximumConnectionsException : Exception
    {
        #region Constructor

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

    #region LicenseResevationException
    [DataContract()]
    [Serializable()]
    public class LicenseResevationException : Exception
    {
        #region Constructor

        public LicenseResevationException(string message)
            : base(message)
        { }

        public LicenseResevationException() : base() { }

        public LicenseResevationException(string message, System.Exception inner) : base(message, inner) { }

        protected LicenseResevationException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        #endregion
    } 
    #endregion
}
