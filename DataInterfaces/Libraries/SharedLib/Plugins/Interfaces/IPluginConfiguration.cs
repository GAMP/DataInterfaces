using System;

namespace SharedLib.Plugins
{
    public interface IPluginConfiguration
    {
        string FileName { get; set; }
        string FilePath { get; set; }
        bool IsEditable { get; set; }
        bool Load { get; set; }
        ModuleScopes Scope { get; set; }
    }
}
