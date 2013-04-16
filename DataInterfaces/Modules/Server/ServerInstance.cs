using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerService
{
    /// <summary>
    /// This class gives the developer access to the current Gizmo Server API instance.
    /// </summary>
    public static class ServerInstance
    {
        public static IServiceViewModel ViewModel
        {
            get;
            set;
        }
        public static IService Instance
        {
            get;
            set;
        }

    }
}
