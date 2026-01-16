using Client;
using SharedLib;

namespace IntegrationLib
{
    /// <summary>
    /// License manager base class.
    /// </summary>
    public abstract class LicenseManagerBase : PropertyChangedNotificator, ILicenseManagerPlugin
    {
        public virtual void Install(IApplicationLicense license, IExecutionContext context, ref bool processCreated)
        {
        }

        public virtual void Uninstall(IApplicationLicense license)
        {
        }
    }    
}
