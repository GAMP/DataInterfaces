using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ReservationEventArgs(int reservationId)
        {
            Id = reservationId;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets reservation id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int Id
        {
            get; protected set;
        } 

        #endregion
    }
}
