using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Modules
{
    #region IPlugableManagerModule
    /// <summary>
    /// Manager plugable plugin module interface.
    /// </summary>
    public interface IManagerPlugableModule : IPluginModule ,
        ISwitchinModule<IManagerPlugableModule>
    {
        /// <summary>
        /// Gets instanse of modules side view.
        /// </summary>
        FrameworkElement SideView { get; }

        /// <summary>
        /// Gets instance of modules main view.
        /// </summary>
        FrameworkElement MainView { get; }

        /// <summary>
        /// Deinitialize plugin.
        /// </summary>
        void Deinitialize();
    }
    #endregion
}
