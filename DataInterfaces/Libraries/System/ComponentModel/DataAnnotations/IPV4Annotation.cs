using System.Net;

namespace System.ComponentModel.DataAnnotations
{
    #region IPV4Annotation
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class IPV4Annotation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return IPAddress.TryParse(value.ToString(), out IPAddress ip) && ip.ToString().CompareTo(value) == 0 && ip.AddressFamily == Net.Sockets.AddressFamily.InterNetwork;
        }
    }
    #endregion
}
