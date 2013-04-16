using System;
namespace CoreLib.Diagnostics
{
    #region ICoreProcessKillInfo
    public interface ICoreProcessKillInfo
    {
        string ModulePath { get; set; }
        int ProcessId { get; set; }
        string ProcessName { get; set; }
        bool Recurse { get; set; }
        bool RespectPath { get; set; }
        bool Tree { get; set; }
    } 
    #endregion
}
