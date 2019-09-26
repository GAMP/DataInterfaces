using System;
using System.Runtime.Serialization;

namespace CoreLib
{
    /// <summary>
    /// Exception event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ExceptionEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="exception">Exception instance.</param>
        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets exception object instance.
        /// </summary>
        [DataMember()]
        public Exception Exception
        {
            get;
            protected set;
        }

        #endregion
    }
}
