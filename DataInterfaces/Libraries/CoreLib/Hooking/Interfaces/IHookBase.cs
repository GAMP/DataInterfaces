using System;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Base hook implementation interface.
    /// </summary>
    public interface IHookBase
    {
        #region PROPERTIES

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

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Installs hook.
        /// </summary>
        void Hook();

        /// <summary>
        /// Uninstalls hook.
        /// </summary>
        void Unhook();

        #endregion
    }
}
