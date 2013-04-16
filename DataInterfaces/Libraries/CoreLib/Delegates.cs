using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using CoreLib.Diagnostics;

namespace CoreLib
{
    #region delegates
    public delegate void ProcessEventDelegate(object sender, ICoreProcess process);
    public delegate void ExceptionEventDelegate(object sender, ExceptionEventArgs args);
    #endregion
    public class ExceptionEventArgs : EventArgs
    {
        #region Fileds
        private Exception ex;
        #endregion
        public ExceptionEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
        public Exception Exception
        {
            get { return this.ex; }
            protected set { this.ex = value; }
        }
    }
}
