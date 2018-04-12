namespace CoreLib.Hooking
{
    #region IShellHook
    public interface IShellHook
    {
        int HookMessageId { get; }
        event GizmoShell.WindowEventDelegate RudeAppActivated;
        event GizmoShell.ShellCommandDelegate ShellCommand;
        event GizmoShell.WindowEventDelegate WindowActivated;
        event GizmoShell.WindowEventDelegate WindowCreated;
        event GizmoShell.WindowEventDelegate WindowDestroyed;
        event GizmoShell.WindowEventDelegate WindowFlashing;
        event GizmoShell.WindowEventDelegate WindowRedrawn;
        event GizmoShell.WindowEventDelegate WindowReplaced;
        event GizmoShell.WindowEventDelegate WindowReplacing;
    } 
    #endregion
}
