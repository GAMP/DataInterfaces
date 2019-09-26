using System.ComponentModel.Composition;

namespace ServerService
{
    /// <summary>
    /// Base class for hook plugin.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServiceHookPlugin))]
    public abstract class GizmoServiceHookPluginBase : GizmoServicePluginBase, IGizmoServiceHookPlugin
    {
    }
}
