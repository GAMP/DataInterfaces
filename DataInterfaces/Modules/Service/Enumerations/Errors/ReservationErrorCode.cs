namespace ServerService
{
    #region ReservationErrorCode
    /// <summary>
    /// Reservation error codes.
    /// </summary>
    public enum ReservationErrorCode
    {
        AlreadyAdded = 0,
        NotPresent = 1,
        ReservationInactive = 2,
        InvalidDate = 3,
        InvalidDuration = 4,
        Overlap = 5,
    } 
    #endregion
}
