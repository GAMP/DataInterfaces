using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// License reservation exception.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class LicenseResevationException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public LicenseResevationException(string message)
            : base(message)
        { }


        /// <summary>
        /// Creates new instance.
        /// </summary>
        public LicenseResevationException() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public LicenseResevationException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected LicenseResevationException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        #endregion
    }
}
