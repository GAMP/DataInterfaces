using System;

namespace CoreLib
{
    public interface ISystemStatus
    {
        int CPULevel { get; set; }
        TimeSpan ProcessUpTime { get; }
        TimeSpan SystemUpTime { get; }
        int TotalThreads { get; }
    }
}
