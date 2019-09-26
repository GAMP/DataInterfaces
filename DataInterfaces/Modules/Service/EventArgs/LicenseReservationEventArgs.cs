using IntegrationLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region LICENSERESERVATIONEVENTARGS
    [Serializable()]
    [DataContract()]
    public class LicenseReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public LicenseReservationEventArgs(ILicenseReservation reservation, bool released)
        {
            Released = released;
            Reservation = reservation ?? throw new ArgumentNullException("reservation");
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public bool Released
        {
            get;
            private set;
        }

        [DataMember()]
        public ILicenseReservation Reservation
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion
}
