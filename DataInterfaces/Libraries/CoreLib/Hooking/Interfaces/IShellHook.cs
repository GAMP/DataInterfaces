namespace CoreLib.Hooking
{
    public interface IShellHook
    {
        #region PROPERTIES

        /// <summary>
        /// Gets hook message id.
        /// </summary>
        /// <remarks>
        /// The id is provided by system upon shell hook installation and used to distinguish hook messages.
        /// </remarks>
        int HookMessageId { get; }

        #endregion

        #region EVENTS

        event GizmoShell.WindowEventDelegate RudeAppActivated;
        event GizmoShell.ShellCommandDelegate ShellCommand;
        event GizmoShell.WindowEventDelegate WindowActivated;
        event GizmoShell.WindowEventDelegate WindowCreated;
        event GizmoShell.WindowEventDelegate WindowDestroyed;
        event GizmoShell.WindowEventDelegate WindowFlashing;
        event GizmoShell.WindowEventDelegate WindowRedrawn;
        event GizmoShell.WindowEventDelegate WindowReplaced;
        event GizmoShell.WindowEventDelegate WindowReplacing;

        #endregion
    }
}
