namespace ServerService
{
    /// <summary>
    /// Reservation pass result.
    /// </summary>
    public enum ReservationPassResult
    {
        /// <summary>
        /// Sucess.
        /// </summary>
        Sucess=0,
        /// <summary>
        /// Pass failed.
        /// </summary>
        Failed=1,
        /// <summary>
        /// Internal error.
        /// </summary>
        Error=2,
        /// <summary>
        /// Pin invalid.
        /// </summary>
        InvalidPin=3,
        /// <summary>
        /// Invalid host id specified.
        /// </summary>
        InvalidHostId=4,
        /// <summary>
        /// Invalid user id specified.
        /// </summary>
        InvalidUserId=5,
    }
}
