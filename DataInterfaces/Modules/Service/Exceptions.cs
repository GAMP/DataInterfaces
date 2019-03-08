using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region MAXIMUMCONNECTIONSEXCEPTION
    /// <summary>
    /// This exception is thrown when maximum client connections reached.
    /// </summary>
    [Serializable]
    [DataContract()]
    public class MaximumConnectionsException : Exception
    {
        #region CONSTRUCTOR

        public MaximumConnectionsException(string message)
            : base(message)
        { }

        public MaximumConnectionsException() : base() { }

        public MaximumConnectionsException(string message, Exception inner) : base(message, inner) { }

        protected MaximumConnectionsException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
        
        #endregion
    }
    #endregion

    #region LICENSERESEVATIONEXCEPTION
    [DataContract()]
    [Serializable()]
    public class LicenseResevationException : Exception
    {
        #region CONSTRUCTOR

        public LicenseResevationException(string message)
            : base(message)
        { }

        public LicenseResevationException() : base() { }

        public LicenseResevationException(string message, System.Exception inner) : base(message, inner) { }

        protected LicenseResevationException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        #endregion
    }
    #endregion

    #region HOSTRESERVATIONEXCEPTION
    public class HostReservationException : GizmoDALV2.ErrorCodeException<ReservationErrorCode>
    {
        public HostReservationException(ReservationErrorCode errorCode) : base(errorCode)
        { }
    } 
    #endregion

    public enum ReservationErrorCode
    {
        InvalidUserId,
        InvalidReservationId,
        UserAlreadyAdded,
        UserNotPresent,
        ReservationInactive,
        InvalidDate,
        InvalidDuration,
        Failed,
    }
}
