using System;

namespace Client.Exceptions
{
    /// <summary>
    /// Thrown when app executable execution failed.
    /// </summary>
    [Serializable()]
    public class ContextExecutionFailedException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ContextExecutionFailedException(string message)
            : base(message)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ContextExecutionFailedException() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ContextExecutionFailedException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected ContextExecutionFailedException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        #endregion
    }
}
