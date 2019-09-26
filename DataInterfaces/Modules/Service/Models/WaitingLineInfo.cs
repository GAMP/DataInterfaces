using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Waiting line info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class WaitingEntryInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets host group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int HostGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets estimated host id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int? EstimatedHostId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets estimated time.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public double? EstimatedWaitTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public WaitingLineState State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets position.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int Position
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if position is manually set.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public bool IsManualPosition
        {
            get; set;
        }

        /// <summary>
        /// Gets total time in waiting line.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public double TimeInLine
        {
            get;set;
        }

        /// <summary>
        /// Gets ready time.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public double ReadyTime
        {
            get; set;
        }

        /// <summary>
        /// Gets if ready timed out.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public bool IsReadyTimedOut
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets entry id.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public int EntryId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created time.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public DateTime CreatedTime
        {
            get;set;
        }

        #endregion
    }
}
