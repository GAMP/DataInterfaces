using IntegrationLib;
using System;

namespace ServerService
{
    /// <summary>
    /// Licenses reservation event args.
    /// </summary>
    public sealed class LicenseReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="reservation">License reservation.</param>
        /// <param name="released">Indicates a release.</param>
        public LicenseReservationEventArgs(ILicenseReservation reservation, bool released)
        {
            Released = released;
            Reservation = reservation ?? throw new ArgumentNullException(nameof(reservation));
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if reservation was released.
        /// </summary>
        public bool Released
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets license reservation.
        /// </summary>
        public ILicenseReservation Reservation
        {
            get;
            private set;
        }

        #endregion
    }
}
