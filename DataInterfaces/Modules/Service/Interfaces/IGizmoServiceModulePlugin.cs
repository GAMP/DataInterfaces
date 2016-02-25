using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// Gizmo service module plugin interface.
    /// </summary>
    public interface IGizmoServiceModulePlugin : IGizmoServicePlugin
    {
        /// <summary>
        /// Initializes plugin.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starting plugin.
        /// </summary>
        void Start();

        /// <summary>
        /// Stopping plugin.
        /// </summary>
        void Stop();
    }
}
