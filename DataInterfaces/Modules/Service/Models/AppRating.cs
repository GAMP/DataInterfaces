using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// App rating dto.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class AppRating
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets app id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int AppId
        {
            get; set;
        }

        /// <summary>
        /// Gets toatl ratings count.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int RatingsCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets average rating value.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public virtual int Value
        {
            get; set;
        }

        #endregion
    }
}
