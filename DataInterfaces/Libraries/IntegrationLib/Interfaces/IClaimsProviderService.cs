using System.Collections.Generic;

namespace IntegrationLib
{
    /// <summary>
    /// Claim type info provider interface.
    /// </summary>
    public interface IClaimTypeInfoProvider
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets all available claim type infos.
        /// </summary>
        /// <returns>A list of supported claim type infos.</returns>
        IEnumerable<IClaimTypeInfo> Get(); 

        #endregion
    }
}
