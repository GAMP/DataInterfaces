using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public interface IManagerLogService
    {
        /// <summary>
        /// Occurs once a new message added to manager message log.
        /// </summary>
        event EventHandler<MessageLogEventArgs> MessageEvent;
    }
}
