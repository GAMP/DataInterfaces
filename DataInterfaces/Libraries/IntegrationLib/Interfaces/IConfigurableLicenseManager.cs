using System.Windows.Controls;

namespace IntegrationLib
{
    /// <summary>
    /// Configurable license management plugin implementation interface.
    /// </summary>
    public interface IConfigurableLicenseManager : ILicenseManagerPlugin, IConfigurablePlugin
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets configurtion UI.
        /// </summary>
        /// <returns>Configuration user control.</returns>
        UserControl GetConfigurationUI();

        #endregion
    }
}
