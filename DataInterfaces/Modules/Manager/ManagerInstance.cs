using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    /// <summary>
    /// This class gives the developer access to the current Gizmo Manager API instance.
    /// </summary>
    public static class ManagerInstance
    {
        public static IManagerViewModel ViewModel
        {
            get;
            set;
        }
        public static ISystemManager Instance
        {
            get;
            set;
        }
    }
}
