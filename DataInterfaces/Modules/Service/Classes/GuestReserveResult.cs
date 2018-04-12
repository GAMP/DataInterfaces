using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class GuestReserveResult
    {
        #region CONSTRUCTOR

        public GuestReserveResult(UserReserveResult result)
        {
            this.UserId = null;
            this.Result = result;
        }

        public GuestReserveResult(int userId) : this(userId, UserReserveResult.Sucess)
        {
        }

        public GuestReserveResult(int userId, UserReserveResult result)
        {
            this.Result = result;
            this.UserId = userId;
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
            get;set;
        }

        /// <summary>
        /// Gets user entity.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public object Entity
        {
            get;set;
        }

        #endregion
    }
}
