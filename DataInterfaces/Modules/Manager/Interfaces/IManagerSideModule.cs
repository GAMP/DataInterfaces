using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Modules
{
    /// <summary>
    /// Side module plugin interface.
    /// </summary>
    public interface IManagerSideModule : IPluginModule , 
        ISwitchinModule<IManagerSideModule>
    {
        /// <summary>
        /// Gets module view.
        /// </summary>
        FrameworkElement View
        {
            get;
        }
    }
}
