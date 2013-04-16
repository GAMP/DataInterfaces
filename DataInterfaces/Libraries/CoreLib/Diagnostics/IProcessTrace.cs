using System;
using CyClone.Core;
namespace CoreLib.Diagnostics
{
    #region IProcessTrace
    public interface IProcessTrace
    {
        event ErrorEventDelegate ErrorEvent;
        bool IsEnabled { get; set; }
        System.Collections.Generic.List<ICoreProcessKillInfo> Restrictions { get; }
    } 
    #endregion
}
