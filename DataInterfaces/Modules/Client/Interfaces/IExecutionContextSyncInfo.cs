using System;

namespace Client
{
    #region IExecutionContextSyncInfo
    public interface IExecutionContextSyncInfo
    {
        global::SharedLib.Applications.IDeploymentProfile Profile { get; }
        global::CyClone.Core.IcySync Syncer { get; }
    } 
    #endregion
}
