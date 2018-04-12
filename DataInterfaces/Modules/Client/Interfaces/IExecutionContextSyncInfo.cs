namespace Client
{
    #region IExecutionContextSyncInfo
    public interface IExecutionContextSyncInfo
    {
        SharedLib.Applications.IDeploymentProfile Profile { get; }
        CyClone.Core.IcySync Syncer { get; }
    } 
    #endregion
}
