using System;
namespace SharedLib.Applications
{
    public interface IRating
    {
        int ApplicationId { get; }
        DateTime LastRated { get; set; }
        int RatesCount { get; set; }
        double Value { get; set; }
    }
}
