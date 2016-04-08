using SharedLib.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    #region IConfigurableService
    public interface IConfigurableService
    {
        /// <summary>
        /// Gets service configuration.
        /// </summary>
        /// <returns>Root service configuration.</returns>
        ConfigurationRoot ConfigurationGet();

        /// <summary>
        /// Sets service configuration.
        /// </summary>
        /// <param name="configuration">Service configuration root.</param>
        void ConfigurationSet(ConfigurationRoot configuration);
    }
    #endregion
}
