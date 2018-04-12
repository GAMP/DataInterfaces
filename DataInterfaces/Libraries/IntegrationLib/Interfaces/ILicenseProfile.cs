using System;
using System.Collections.ObjectModel;

namespace IntegrationLib
{
    public interface ILicenseProfile
    {
        Guid Guid { get; set; }
        ObservableCollection<IApplicationLicense> Licenses { get; }
        string ManagerPlugin { get; set; }
        string Name { get; set; }
        string PluginAssembly { get; set; }
        IPluginSettings PluginSettings { get; set; }
        void SetManager(IntegrationLib.ILicenseManagerPlugin manager);
    }
}
