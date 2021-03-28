using System;
using System.Runtime.Serialization;

namespace Gizmo.Shared.Exceptions
{
    #region ERRORCODEEXCEPTIONBASE

    /// <summary>
    /// Generic error code exception.
    /// </summary>
    /// <typeparam name="TErrorCode">Error code type.</typeparam>
    [DataContract()]
    [Serializable()]
    public abstract class ErrorCodeExceptionBase<TErrorCode> : Exception where TErrorCode : Enum
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public ErrorCodeExceptionBase(TErrorCode errorCode)
            : base()
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="errorCode">Error code.</param>
        public ErrorCodeExceptionBase(string message, TErrorCode errorCode) : this(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ErrorCodeExceptionBase() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ErrorCodeExceptionBase(string message)
          : base(message)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ErrorCodeExceptionBase(string message, Exception inner)
            : base(message, inner)
        { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected ErrorCodeExceptionBase(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                ErrorCode = (TErrorCode)info.GetValue(nameof(ErrorCode), typeof(TErrorCode));
            }
        }

        /// <summary>
        /// Gets object data.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(ErrorCode), ErrorCode);
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets exception error code.
        /// </summary>
        [DataMember()]
        public TErrorCode ErrorCode
        {
            get; protected set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Converts exception to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} failed with error {1}", GetType().FullName, ErrorCode);
        }

        #endregion
    }

    #endregion
}
