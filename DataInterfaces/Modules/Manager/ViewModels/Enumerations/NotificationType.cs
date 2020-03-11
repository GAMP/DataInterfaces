namespace Manager.ViewModels
{
    /// <summary>
    /// Manager notification type.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// New order notification.
        /// </summary>
        NewOrder = 0,

        /// <summary>
        /// Guest logout notification.
        /// </summary>
        GuestLogout = 1,

        /// <summary>
        /// Member logout notification.
        /// </summary>
        MemberLogout = 2,

        /// <summary>
        /// Client disconnect notification.
        /// </summary>
        ClientDisconnect = 3,
    }
}
