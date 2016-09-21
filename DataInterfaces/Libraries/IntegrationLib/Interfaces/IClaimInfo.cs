using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    /// <summary>
    /// Claim info interface.
    /// </summary>
    public interface IClaimInfo
    {
        /// <summary>
        /// Gets friendly name.
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets operation.
        /// </summary>
        string Operation { get; }

        /// <summary>
        /// Gets resource.
        /// </summary>
        string Resource { get; }
    }
}
