using System.Windows.Controls;

namespace IntegrationLib
{
    public interface IConfigurableLicenseManager : ILicenseManagerPlugin, IConfigurablePlugin
    {
        #region FUNCTIONS

        UserControl GetConfigurationUI();

        #endregion
    }
}
