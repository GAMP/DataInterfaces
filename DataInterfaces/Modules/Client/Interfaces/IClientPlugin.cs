using Client;
using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    /// <summary>
    /// Client plugin interface.
    /// </summary>
    public interface IClientPlugin : IPlugin
    {
        /// <summary>
        /// Gets client instance.
        /// </summary>
        IClient Client
        {
            get;
        }
    }
}
