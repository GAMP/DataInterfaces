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
    public abstract class ErrorCodeExceptionBase<TErrorCode> : Exception
    {
        #region CONSTRUCTOR

        public ErrorCodeExceptionBase(TErrorCode errorCode)
            : base()
        {
            ErrorCode = errorCode;
        }

        public ErrorCodeExceptionBase(string message, TErrorCode errorCode) : this(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodeExceptionBase() : base() { }

        public ErrorCodeExceptionBase(string message)
          : base(message)
        { }

        public ErrorCodeExceptionBase(string message, Exception inner)
            : base(message, inner)
        { }

        protected ErrorCodeExceptionBase(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                ErrorCode = (TErrorCode)info.GetValue(nameof(ErrorCode), typeof(TErrorCode));
            }
        }

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

        public override string ToString()
        {
            return string.Format("{0} failed with error {1}", GetType().FullName, ErrorCode);
        }

        #endregion
    }

    #endregion
}
