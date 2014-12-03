using System;
namespace CoreLib.Diagnostics
{
    public interface ICoreProcessModule
    {
        string CompanyName { get; }
        string Description { get; }
        string ModuleName { get; }
        string FileName { get; }
        string FileVersion { get; }
    }
}
