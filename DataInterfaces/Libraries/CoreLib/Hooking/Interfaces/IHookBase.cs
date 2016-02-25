using System;

namespace CoreLib.Hooking
{
    #region IHookBase
    public interface IHookBase
    {
        /// <summary>
        /// Installs hook.
        /// </summary>
        void Hook();

        /// <summary>
        /// Gets intsalled hooke handle.
        /// </summary>
        IntPtr HookHandle { get; }

        /// <summary>
        /// Gets if hook is installed.
        /// </summary>
        bool IsHooked { get; }

        /// <summary>
        /// Gets module handle.
        /// </summary>
        IntPtr ModuleHandle { get; }

        /// <summary>
        /// Uninstalls hook.
        /// </summary>
        void Unhook();
    } 
    #endregion
}
