using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    #region ExecutionFailedException
    /// <summary>
    /// Thrown when execution failed.
    /// </summary>
    [Serializable()]
    public class ContextExecutionFailedException : Exception
    {
        #region Constructor
        public ContextExecutionFailedException(string message)
            : base(message)
        { }
        public ContextExecutionFailedException() : base() { }
        public ContextExecutionFailedException(string message, System.Exception inner) : base(message, inner) { }
        protected ContextExecutionFailedException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
        #endregion
    }
    #endregion
}
