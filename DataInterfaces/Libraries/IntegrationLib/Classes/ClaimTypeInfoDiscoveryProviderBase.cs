using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    /// <summary>
    /// Base class for claim info discovery providers.
    /// </summary>
    public abstract class ClaimTypeInfoDiscoveryProviderBase : IClaimTypeInfoDiscoveryProvider
    {
        #region ABSTRACT FUNCTIONS
        
        /// <summary>
        /// Gets supported claim types.
        /// </summary>
        /// <returns>When implemented returns a list of supported claim types.</returns>
        public abstract IEnumerable<IClaimTypeInfo> Get(); 

        #endregion
    }
}
