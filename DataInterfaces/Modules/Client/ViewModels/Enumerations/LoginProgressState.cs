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
        /// <summary>
        /// Initial.
        /// </summary>
        Initial = 0,
        /// <summary>
        /// Login.
        /// </summary>
        Login = 1,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = 2,
        /// <summary>
        /// Logout.
        /// </summary>
        Logout = 3,
    }
}
