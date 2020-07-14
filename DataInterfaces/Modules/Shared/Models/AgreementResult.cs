using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace Gizmo.Shared
{
    /// <summary>
    /// Agreement result model.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    [Serializable()]
    public class AgreementResult
    {
        #region CONSTRUCTOR

        public AgreementResult() : this(AgreementResultCode.NotSet)
        { }

        public AgreementResult(AgreementResultCode resultCode)
        {
            ResultCode = resultCode;
        }

        public AgreementResult(AgreementResultCode resultCode, string agreement) : this(resultCode)
        {
            if (string.IsNullOrWhiteSpace(agreement))
                throw new ArgumentNullException(nameof(agreement));
            Agreement = agreement;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets result code.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public AgreementResultCode ResultCode
        {
            get; protected set;
        }

        /// <summary>
        /// Gets agreement textual representation.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Agreement
        {
            get; set;
        }

        #endregion
    }
}
