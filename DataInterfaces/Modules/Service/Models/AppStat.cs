using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// App stat dto.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class AppStat
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets app id.
        /// </summary>
        [ProtoMember(1)]
        public int AppId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total executions.
        /// </summary>
        [ProtoMember(2)]
        public int TotalExecutions
        {
            get; set;
        }

        /// <summary>
        /// Gets total span.
        /// </summary>
        [ProtoMember(3)]
        public double TotalSpan
        {
            get; set;
        }

        #endregion
    }
}
