namespace Client.ViewModels
{
    /// <summary>
    /// Defines login progress state.
    /// </summary>
    /// <remarks>
    /// The purpose of state is to simplify siwtching Views to appropriate state based on current user login state.
    /// </remarks>
    public enum LoginProgressState : int
    {
        Initial = 0,
        Login = 1,
        Failed = 2,
        Logout = 3,
    }
}
