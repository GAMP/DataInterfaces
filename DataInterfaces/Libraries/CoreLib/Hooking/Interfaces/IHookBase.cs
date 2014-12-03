using System;

namespace CoreLib.Hooking
{
    #region IHookBase
    public interface IHookBase
    {
        void Hook();
        IntPtr HookHandle { get; }
        bool IsHooked { get; }
        IntPtr ModuleHandle { get; }
        void Unhook();
    } 
    #endregion
}
