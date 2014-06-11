using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using CoreLib.Diagnostics;

namespace CoreLib
{
    #region DELEGATES
    public delegate void ProcessEventDelegate(object sender, ICoreProcess process);
    public delegate void ExceptionEventDelegate(object sender, ExceptionEventArgs args);
    #endregion

    #region ExceptionEventArgs
    public class ExceptionEventArgs : EventArgs
    {
        #region FIELDS
        private Exception ex;
        #endregion

        #region CONSTRUCTOR
        public ExceptionEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets or sets exception object.
        /// </summary>
        public Exception Exception
        {
            get { return this.ex; }
            protected set { this.ex = value; }
        }
        #endregion
    } 
    #endregion
}
