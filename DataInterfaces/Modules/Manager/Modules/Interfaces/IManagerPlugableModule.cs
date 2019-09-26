using IntegrationLib;
using System.Windows;

namespace Manager.Modules
{
    /// <summary>
    /// Manager plugable plugin module interface.
    /// </summary>
    public interface IManagerPlugableModule : IPluginModule,
        ISwitchinModule<IManagerPlugableModule>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets instanse of modules side view.
        /// </summary>
        FrameworkElement SideView { get; }

        /// <summary>
        /// Gets instance of modules main view.
        /// </summary>
        FrameworkElement MainView { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Deinitialize plugin.
        /// </summary>
        void Deinitialize();

        #endregion
    }
}
