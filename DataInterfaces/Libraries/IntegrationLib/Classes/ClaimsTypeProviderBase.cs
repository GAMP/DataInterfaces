using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    /// <summary>
    /// Base class for claim info providers.
    /// </summary>
    public abstract class ClaimsInfoProviderBase : IClaimInfoProvider
    {
        public abstract IEnumerable<IClaimInfo> Get();
    }
}
