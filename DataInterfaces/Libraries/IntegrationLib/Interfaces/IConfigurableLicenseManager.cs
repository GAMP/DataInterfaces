using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace IntegrationLib
{
    #region IConfigurableLicenseManager
    public interface IConfigurableLicenseManager : ILicenseManagerPlugin, IConfigurablePlugin
    {
        UserControl GetConfigurationUI();
    }
    #endregion
}
