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

            IPAddress ip;
            return IPAddress.TryParse(value.ToString(), out ip) && ip.ToString().CompareTo(value) == 0 && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
        }
    }
    #endregion
}
