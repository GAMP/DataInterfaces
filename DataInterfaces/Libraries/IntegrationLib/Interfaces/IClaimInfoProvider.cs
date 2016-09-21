using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    /// <summary>
    /// Claims information provider.
    /// </summary>
    public interface IClaimInfoProvider
    {
        /// <summary>
        /// Gets claim types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IClaimInfo> Get();
    }
}
