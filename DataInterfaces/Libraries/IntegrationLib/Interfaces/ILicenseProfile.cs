using System;
using System.Collections.ObjectModel;

namespace IntegrationLib
{
    /// <summary>
    /// License profile implementation interface.
    /// </summary>
    public interface ILicenseProfile
    {
        #region PROPERTIES

        /// <summary>
        /// Guid.
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Licenses.
        /// </summary>
        ObservableCollection<IApplicationLicense> Licenses { get; }

        /// <summary>
        /// Manager plugin.
        /// </summary>
        string ManagerPlugin { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Manager plugin assembly.
        /// </summary>
        string PluginAssembly { get; set; }

        /// <summary>
        /// Manager plugin settings.
        /// </summary>
        IPluginSettings PluginSettings { get; set; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Sets manager.
        /// </summary>
        /// <param name="manager">License manager instance.</param>
        void SetManager(ILicenseManagerPlugin manager);

        #endregion
    }
}
