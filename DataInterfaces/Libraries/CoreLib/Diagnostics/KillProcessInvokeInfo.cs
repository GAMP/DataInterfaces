using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib.Diagnostics
{
    #region KillProcessInvokeInfo
    public class KillProcessInvokeInfo : MarshalByRefObject
    {
        #region Constructor
        /// <summary>
        /// Create new instance of KillProcessInvokeInfo.
        /// </summary>
        /// <param name="invoker">Invoking delegate.</param>
        /// <param name="killInfo">IProcessKillInfo instance.</param>
        public KillProcessInvokeInfo(BeginProcessKillDelegate invoker,
            ICoreProcessKillInfo killInfo)
        {
            #region Validation
            if (invoker == null)
            {
                throw new ArgumentNullException("Invoker", "Delegate instance may not be null.");
            }
            if (killInfo == null)
            {
                throw new ArgumentNullException("KillInfo", "KillInfo instance may not be null.");
            }
            #endregion

            #region Assign values
            this.Delegate = invoker;
            this.KillInfo = killInfo;
            #endregion
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the delegate of this invocation info.
        /// </summary>
        public BeginProcessKillDelegate Delegate
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the KillInfo parameters passed to the invocation.
        /// </summary>        
        public ICoreProcessKillInfo KillInfo
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
