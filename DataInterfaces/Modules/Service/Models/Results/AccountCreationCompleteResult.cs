using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Account creation complete result model.
    /// </summary>
    /// <remarks>
    /// Used with non-verified account creation.
    /// </remarks>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationCompleteResult
    {
        #region PROPERTIES

        /// <summary>
        /// Result code.
        /// </summary>
        [ProtoMember(1)]
        public AccountCreationCompleteResultCode Result
        {
            get; set;
        }

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(2)]
        public int? UserId
        {
            get; set;
        }

        #endregion
    } 
}
