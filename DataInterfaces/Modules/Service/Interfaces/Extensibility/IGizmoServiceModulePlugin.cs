namespace ServerService
{
    /// <summary>
    /// Gizmo service module plugin interface.
    /// </summary>
    public interface IGizmoServiceModulePlugin : IGizmoServicePlugin
    {
        #region FUNCTIONS
        
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

        #endregion
    }
}
