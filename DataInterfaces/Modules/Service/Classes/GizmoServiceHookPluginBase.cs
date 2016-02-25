using System.ComponentModel.Composition;

namespace ServerService
{
    #region GizmoServiceHookPluginBase
    /// <summary>
    /// Base class for hook plugin.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServiceHookPlugin))]
    public abstract class GizmoServiceHookPluginBase : GizmoServicePluginBase, IGizmoServiceHookPlugin
    {
    }
    #endregion 
}
