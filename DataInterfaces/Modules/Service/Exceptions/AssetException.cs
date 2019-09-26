using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region ASSETEXCEPTION
    [Serializable()]
    [DataContract()]
    public class AssetException : ErrorCodeExceptionBase<AssetErrorCode>
    {
        #region CONSTRUCTOR

        public AssetException(AssetErrorCode errorCode) : base(errorCode)
        { }

        protected AssetException(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
