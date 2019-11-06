using System.Windows;
using Client;

namespace IntegrationLib
{
    /// <summary>
    /// License Manager interface.
    /// </summary>
    public interface ILicenseManagerPlugin : IPlugin
    {
        #region FUNCTIONS

        /// <summary>
        /// Installs the license.
        /// </summary>
        /// <param name="key">IApplicationLicense.</param>
        /// <param name="context">IExecutionContext context.</param>
        /// <param name="forceCreation">Sets if process creation should be forced even if execution process is alive.</param>
        void Install(IApplicationLicense key, IExecutionContext context, ref bool forceCreation);

        /// <summary>
        /// Uninstalls the license.
        /// </summary>
        /// <param name="license">IApplicationLicense.</param>
        void Uninstall(IApplicationLicense license);

        /// <summary>
        /// Gets the instance of the application license.
        /// </summary>
        /// <returns>IApplicationLicenseKey instance.</returns>
        IApplicationLicenseKey GetLicense(ILicenseProfile profile, ref bool additionHandled, Window owner);

        /// <summary>
        /// Edit existing license key.
        /// </summary>
        /// <param name="key">License Key.</param>
        /// <param name="profile">License profile.</param>
        /// <param name="additionHandled">Indicates if addition of license was handled.</param>
        /// <param name="owner">Dialog owner window.</param>
        /// <returns>IApplicationLicenseKey instance.</returns>
        IApplicationLicenseKey EditLicense(IApplicationLicenseKey key, ILicenseProfile profile, ref bool additionHandled, Window owner);

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if licenses can be edited by this plugin.
        /// </summary>
        bool CanEdit { get; }

        /// <summary>
        /// Gets if licenses can be added to this plugin.
        /// </summary>
        bool CanAdd { get; }

        #endregion
    }
}
