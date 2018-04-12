using System.Collections.Generic;

namespace IntegrationLib
{
    /// <summary>
    /// Claim type info discovery provider.
    /// </summary>
    public interface IClaimTypeInfoDiscoveryProvider
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets supported claim type infos.
        /// </summary>
        /// <returns>A list of supported claim type infos.</returns>
        IEnumerable<IClaimTypeInfo> Get(); 

        #endregion
    }
}
