namespace ServerService
{
    /// <summary>
    /// Reservation error codes.
    /// </summary>
    public enum ReservationErrorCode
    {
        /// <summary>
        /// Entry already added to reservation.
        /// </summary>
        AlreadyAdded = 0,

        /// <summary>
        /// Entry not pre
        /// </summary>
        NotPresent = 1,

        /// <summary>
        /// Reservation is inactive.
        /// </summary>
        ReservationInactive = 2,

        /// <summary>
        /// Invalid reservation date.
        /// </summary>
        InvalidDate = 3,

        /// <summary>
        /// Invalid reservation duration.
        /// </summary>
        InvalidDuration = 4,

        /// <summary>
        /// Reservation overlaps.
        /// </summary>
        Overlap = 5,
    }
}
