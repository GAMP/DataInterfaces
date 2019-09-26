using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Account creation by token result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByTokenCompleteResult : VerificationResultBase<AccountCreationByTokenCompleteResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Newly created user id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(1)]
        public int? CreatedUserId
        {
            get; set;
        }

        #endregion
    }
}
