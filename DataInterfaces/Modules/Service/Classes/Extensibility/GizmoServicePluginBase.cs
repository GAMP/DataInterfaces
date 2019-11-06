using System;
using System.ComponentModel.Composition;

namespace ServerService
{
    /// <summary>
    /// Gizmo service plugin base.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServicePlugin))]
    public abstract class GizmoServicePluginBase : IGizmoServicePlugin, 
        IPartImportsSatisfiedNotification,
        IDisposable
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the service instance.
        /// </summary>
        [Import(typeof(IGizmoService))]
        protected virtual IGizmoService Service
        {
            get;
            private set;
        }

        #endregion

        #region VIRTUAL

        /// <summary>
        /// When overriden should take care of releasing any resources used by plugin.
        /// </summary>
        /// <param name="disposing">Indicate disposing.</param>
        public virtual void OnDisposing(bool disposing)
        {
        }

        #endregion

        #region IPARTIMPORTSSATISFIEDNOTIFICATION
        /// <summary>
        /// This method is called once all imports are satisfied.
        /// </summary>
        public virtual void OnImportsSatisfied()
        {
        }
        #endregion

        #region IDISPOSABLE
        /// <summary>
        /// Called once object is being disposed.
        /// </summary>
        public void Dispose()
        {
            OnDisposing(true);
        }
        #endregion
    }
}
