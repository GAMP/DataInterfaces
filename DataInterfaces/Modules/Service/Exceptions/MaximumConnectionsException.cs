using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// This exception is thrown when maximum client connections reached.
    /// </summary>
    [Serializable]
    [DataContract()]
    public class MaximumConnectionsException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public MaximumConnectionsException(string message)
            : base(message)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public MaximumConnectionsException() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public MaximumConnectionsException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected MaximumConnectionsException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        #endregion
    }
}
