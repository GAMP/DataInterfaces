using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Mobile phone verification start result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class MobilePhoneVerificationStartResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Mobile phone being verified.
        /// </summary>
        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public string MobilePhone
        {
            get; set;
        }

        #endregion
    }
}
