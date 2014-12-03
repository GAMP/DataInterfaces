using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    /// <summary>
    /// Provides access to the current Gizmo Client instance.
    /// </summary>
    [Obsolete("Client access will be handled by MEF in future releases.")]
    public static class ClientInstance
    {
        /// <summary>
        /// Gets or sets clients view model instance.
        /// </summary>
        public static IClientViewModel ViewModel
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets current client instance.
        /// </summary>
        public static IClient Instance
        {
            get;
            set;
        }
    }
}
