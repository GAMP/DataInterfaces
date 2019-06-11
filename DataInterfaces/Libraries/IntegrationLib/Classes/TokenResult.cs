using ProtoBuf;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Result generated with token requests.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class TokenResult
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="token">Token.</param>
        /// <param name="refreshToken">Refresh token.</param>
        public TokenResult(string token, string refreshToken)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));

            RefreshToken = refreshToken;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets token.
        /// </summary>
        [ProtoMember(1)]
        [DataMember(Order = 0)]
        public string Token
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets refresh token.
        /// </summary>
        [ProtoMember(2)]
        [DefaultValue(null)]
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string RefreshToken
        {
            get; protected set;
        } 

        #endregion
    }
}
