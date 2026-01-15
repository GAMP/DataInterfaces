using Client;

namespace IntegrationLib
{
    /// <summary>
    /// License Manager interface.
    /// </summary>
    public interface ILicenseManagerPlugin : IPlugin
    {
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
    }
}
