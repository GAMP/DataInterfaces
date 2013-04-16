using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SharedLib.Applications;

namespace IntegrationLib
{
    public interface ILicenseProfile
    {
        Guid Guid { get; set; }
        System.Collections.ObjectModel.ObservableCollection<IntegrationLib.IApplicationLicense> Licenses { get; }
        string ManagerPlugin { get; set; }
        string Name { get; set; }
        string PluginAssembly { get; set; }
        IntegrationLib.IPluginSettings PluginSettings { get; set; }
        void SetManager(IntegrationLib.ILicenseManagerPlugin manager);

    }
}
