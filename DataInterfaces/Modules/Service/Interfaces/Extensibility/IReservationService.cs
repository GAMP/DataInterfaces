using System;

namespace ServerService
{
    public interface IReservationService
    {
        event EventHandler<ReservationEventArgs> ReservationChange;
    }
}
