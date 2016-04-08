using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    #region ILogService
    public interface ILogService
    {
        #region EVENTS
        /// <summary>
        /// Occurs on log change.
        /// </summary>
        event EventHandler<LogChangeEventArgs> LogChange; 
        #endregion
    }
    #endregion
}
