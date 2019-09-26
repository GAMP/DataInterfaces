using System;

namespace Client.Exceptions
{
    #region ContextExecutionFailedException
    /// <summary>
    /// Thrown when execution failed.
    /// </summary>
    [Serializable()]
    public class ContextExecutionFailedException : Exception
    {
        #region CONSTRUCTOR

        public ContextExecutionFailedException(string message)
            : base(message)
        { }
        
        public ContextExecutionFailedException() : base() { }
        
        public ContextExecutionFailedException(string message, Exception inner) : base(message, inner) { }
        
        protected ContextExecutionFailedException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
        
        #endregion
    }
    #endregion
}
