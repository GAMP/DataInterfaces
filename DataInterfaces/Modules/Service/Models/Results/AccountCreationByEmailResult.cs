using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Account creation by email result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByEmailResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Email address used.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string EmailAddress
        {
            get; set;
        }

        #endregion
    }
}
