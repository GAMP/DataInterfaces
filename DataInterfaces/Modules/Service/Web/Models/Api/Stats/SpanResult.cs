using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Generic class representing time span.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SpanResult
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="seconds">Span seconds.</param>
        public SpanResult(double seconds)
        {
            TotalSeconds = seconds;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets total seconds.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public double TotalSeconds
        {
            get; protected set;
        }

        /// <summary>
        /// Gets total minutes.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public double TotalMinutes
        {
            get { return TimeSpan.FromSeconds(TotalSeconds).TotalMinutes; }
        }

        /// <summary>
        /// Gets total hours.
        /// </summary>
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public double TotalHours
        {
            get { return TimeSpan.FromSeconds(TotalSeconds).TotalHours; }
        } 
        
        #endregion
    }
}
