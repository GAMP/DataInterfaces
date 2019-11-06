namespace CoreLib.Hooking
{
    /// <summary>
    /// Windows shell hook implementation interface.
    /// </summary>
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

        /// <summary>
        /// Raised on rude app activated.
        /// </summary>
        event GizmoShell.WindowEventDelegate RudeAppActivated;

        /// <summary>
        /// Raised on shell command.
        /// </summary>
        event GizmoShell.ShellCommandDelegate ShellCommand;

        /// <summary>
        /// Raised on window activated.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowActivated;

        /// <summary>
        /// Raised on window created.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowCreated;

        /// <summary>
        /// Raised on window destroyed.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowDestroyed;

        /// <summary>
        /// Raised on window flashing.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowFlashing;

        /// <summary>
        /// Raised on window redrawn.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowRedrawn;

        /// <summary>
        /// Raised on window replaced.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowReplaced;

        /// <summary>
        /// Raised on window replacing.
        /// </summary>
        event GizmoShell.WindowEventDelegate WindowReplacing;

        #endregion
    }
}
