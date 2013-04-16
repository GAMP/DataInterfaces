using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using System.Reflection;

namespace IntegrationLib
{
    #region IPlugin
    /// <summary>
    /// Plugin interface.
    /// </summary>
    public interface IPlugin
    {
    }
    #endregion

    #region IConfigurablePlugin
    /// <summary>
    /// Configurable plugin interface.
    /// </summary>
    public interface IConfigurablePlugin : IPlugin
    {
        /// <summary>
        /// Initializes the plugin to passed settings instance.
        /// </summary>
        /// <param name="settings">Settings instance.</param>
        void Initialize(IPluginSettings settings);

        /// <summary>
        /// Gets the instance of the settings used to initialize the plugin.
        /// </summary>
        IPluginSettings Settings { get; }

        /// <summary>
        /// This routine called once plugin initialization has completed.
        /// </summary>
        /// <param name="settings">Settings instance used to initialize the plugin.</param>
        void OnInitialized(IPluginSettings settings);

        /// <summary>
        /// Returns new settings instance for this plugin.
        /// </summary>
        /// <returns>IPlugin settings instance.</returns>
        IPluginSettings GetSettingsInstance();
    }
    #endregion

    #region IPluginSettings
    /// <summary>
    /// Plugin settings interface.
    /// </summary>
    public interface IPluginSettings
    {

    }
    #endregion

    #region IPluginMetadata
    /// <summary>
    /// Plugin metadat interface.
    /// </summary>
    public interface IPluginMetadata
    {
        /// <summary>
        /// Gets the name of plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the version of the plugin.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the description of plugin.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets if icon resource is set.
        /// </summary>
        bool HasIconResource { get; }

        /// <summary>
        /// Gets icon resource name.
        /// </summary>
        string IconResource { get; }
    }
    #endregion    
}
