using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    /// <summary>
    /// This class gives the developer access to the current Gizmo Client API instance.
    /// </summary>
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
        /// <summary>
        /// Gets if the Client insatance is loaded.
        /// </summary>
        public static bool IsLoaded
        {
            get { return ClientInstance.ViewModel != null & ClientInstance.Instance != null; }
        }
    
    }
}
