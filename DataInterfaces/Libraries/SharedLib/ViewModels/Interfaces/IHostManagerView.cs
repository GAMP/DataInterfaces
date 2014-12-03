using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLib;

namespace SharedLib.ViewModels
{
    #region IHostManagerView
    public interface IHostManagerView
    {
        /// <summary>
        /// Gets the hostentry of the view.
        /// </summary>
        IHostEntry HostEntry { get; }

        /// <summary>
        /// Gets if host has a dispatcher.
        /// </summary>
        bool HasDispatcher { get; }

        /// <summary>
        /// Gets if host has a connected dispatcher.
        /// </summary>
        bool HasConnectedDispatcher { get; }
    } 
    #endregion
}
