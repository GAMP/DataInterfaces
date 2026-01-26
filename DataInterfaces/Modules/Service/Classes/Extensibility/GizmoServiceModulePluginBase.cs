using System.ComponentModel.Composition;

namespace ServerService
{
    /// <summary>
    /// Base class for module plugins.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServiceModulePlugin))]
    public abstract class GizmoServiceModulePluginBase : GizmoServicePluginBase,
        IGizmoServiceModulePlugin
    {
        /// <summary>
        /// When overridden responsible of plugin initialization.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// When overridden responsible of starting plugin.
        /// </summary>
        public virtual void Start()
        {
        }

        /// <summary>
        /// When overridden responsible of stopping plugin.
        /// </summary>
        public virtual void Stop()
        {
        } 
    } 
}
