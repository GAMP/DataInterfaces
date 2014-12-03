using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib
{
    #region ExceptionEventArgs
    public class ExceptionEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ExceptionEventArgs(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            this.Exception = exception;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets exception object.
        /// </summary>
        public Exception Exception
        {
            get;
            protected set;
        }
        
        #endregion
    }
    #endregion
}
