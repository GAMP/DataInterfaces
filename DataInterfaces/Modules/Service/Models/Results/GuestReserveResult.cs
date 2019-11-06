using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Guest account reservation result.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class GuestReserveResult
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Reserve result.</param>
        public GuestReserveResult(UserReserveResult result)
        {
            UserId = null;
            Result = result;
        }

        /// <summary>
        /// Creates new instance with successful result.
        /// </summary>
        /// <param name="userId">User id.</param>
        public GuestReserveResult(int userId) : this(userId, UserReserveResult.Success)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="result">Reserve result.</param>
        public GuestReserveResult(int userId, UserReserveResult result)
        {
            Result = result;
            UserId = userId;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets result.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public UserReserveResult Result
        {
            get; set;
        }

        /// <summary>
        /// Gets reserved user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets if new user created or one from pool was used.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public bool IsNewGuest
        {
            get; set;
        }

        /// <summary>
        /// Gets user entity.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public object Entity
        {
            get; set;
        }

        #endregion
    }
}
