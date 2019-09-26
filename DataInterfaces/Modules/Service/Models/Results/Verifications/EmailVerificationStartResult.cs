using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Email verification start result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class EmailVerificationStartResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Email being verified.
        /// </summary>
        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public string Email
        {
            get; set;
        }

        #endregion
    }
}
