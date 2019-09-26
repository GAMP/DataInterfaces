using IntegrationLib;
using System;

namespace ServerService
{
    /// <summary>
    /// Gizmo service plugin interface.
    /// </summary>
    public interface IGizmoServicePlugin : IPlugin ,
        IDisposable
    {
    }
}
