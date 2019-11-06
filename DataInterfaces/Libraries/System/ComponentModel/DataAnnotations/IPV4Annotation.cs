using System.Net;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// IP V4 (InterNetwork) validation annotation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class IPV4Annotation : ValidationAttribute
    {
        #region OVERRIDES
        
        /// <summary>
        /// Checks if address is valid IPV4.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True or false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return IPAddress.TryParse(value.ToString(), out IPAddress ip) && ip.ToString().CompareTo(value) == 0 && ip.AddressFamily == Net.Sockets.AddressFamily.InterNetwork;
        } 

        #endregion
    }
}
