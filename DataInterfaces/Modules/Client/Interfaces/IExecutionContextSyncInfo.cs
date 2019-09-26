namespace Client
{
    /// <summary>
    /// Execution context sync info interface.
    /// </summary>
    public interface IExecutionContextSyncInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets deployment profile.
        /// </summary>
        SharedLib.Applications.IDeploymentProfile Profile { get; }

        /// <summary>
        /// Gets syncer instance.
        /// </summary>
        CyClone.Core.IcySync Syncer { get; } 

        #endregion
    } 
}
