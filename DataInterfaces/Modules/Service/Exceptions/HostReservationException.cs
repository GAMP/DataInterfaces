using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region HOSTRESERVATIONEXCEPTION
    [Serializable]
    [DataContract()]
    public class HostReservationException : ErrorCodeExceptionBase<ReservationErrorCode>
    {
        public HostReservationException(ReservationErrorCode errorCode) : base(errorCode)
        { }
    }
    #endregion
}
