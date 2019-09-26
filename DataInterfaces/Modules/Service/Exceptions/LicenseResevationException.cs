using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region LICENSERESEVATIONEXCEPTION
    [DataContract()]
    [Serializable()]
    public class LicenseResevationException : Exception
    {
        #region CONSTRUCTOR

        public LicenseResevationException(string message)
            : base(message)
        { }

        public LicenseResevationException() : base() { }

        public LicenseResevationException(string message, System.Exception inner) : base(message, inner) { }

        protected LicenseResevationException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        #endregion
    }
    #endregion
}
