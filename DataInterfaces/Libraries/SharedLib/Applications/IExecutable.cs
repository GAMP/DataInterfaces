using System.Diagnostics;

namespace SharedLib.Applications
{
    public interface IExecutable
    {
        int ID { get; }

        string Arguments { get; set; }

        bool AutoLaunch { get; set; }

        string ExecutableName { get; set; }

        string ExecutablePath { get; set; }
    
        bool KillChildren { get; set; }

        ApplicationModes Modes { get; set; }

        bool MonitorChildren { get; set; }

        bool MultiRun { get; set; }

        RunMode RunMode { get; set; }

        string WorkingDirectory { get; set; }

        IDeploymentProfile DefaultDeploymentProfile { get; }

        Process GetProcessForExecutable(IApplicationProfile application);
    }

}
