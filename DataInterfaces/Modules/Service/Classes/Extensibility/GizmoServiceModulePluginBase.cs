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
        #region VIRTUAL FUNCTIONS
        
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

        #endregion
    } 
}
