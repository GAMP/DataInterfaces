using System.ComponentModel.Composition;

namespace ServerService
{
    #region GizmoServiceModulePluginBase
    /// <summary>
    /// Base class for module plugins.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServiceModulePlugin))]
    public abstract class GizmoServiceModulePluginBase : GizmoServicePluginBase,
        IGizmoServiceModulePlugin
    {
        /// <summary>
        /// When overriden responsible of plugin initialization.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// When overriden responsible of starting plugin.
        /// </summary>
        public virtual void Start()
        {
        }

        /// <summary>
        /// When overriden responsible of stopping plugin.
        /// </summary>
        public virtual void Stop()
        {
        }
    } 
    #endregion
}
