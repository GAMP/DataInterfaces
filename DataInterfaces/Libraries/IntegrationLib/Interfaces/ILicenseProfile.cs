using System;
using System.Collections.ObjectModel;

namespace IntegrationLib
{
    public interface ILicenseProfile
    {
        #region PROPERTIES

        Guid Guid { get; set; }

        ObservableCollection<IApplicationLicense> Licenses { get; }

        string ManagerPlugin { get; set; }
        
        string Name { get; set; }

        string PluginAssembly { get; set; }

        IPluginSettings PluginSettings { get; set; }

        #endregion

        #region FUNCTIONS

        void SetManager(ILicenseManagerPlugin manager);

        #endregion
    }
}
