using System;
namespace Client
{
    public interface IExecutionContextSyncInfo
    {
        global::SharedLib.Applications.IDeploymentProfile Profile { get; }
        global::CyClone.Core.IcySync Syncer { get; }
    }
}
