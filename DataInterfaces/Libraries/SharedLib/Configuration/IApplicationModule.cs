using System;

namespace SharedLib.Configuration
{
    public interface IApplicationModule
    {
        string FileName { get; set; }
        ModuleEnum ModuleType { get; set; }
        string ModuleVersion { get; set; }
        string ToString();
    }
}
