using SharedLib;
using System.Threading.Tasks;

namespace ServerService.Services
{
    /// <summary>
    /// SMS delivery service.
    /// </summary>
    public interface ISMSDeliveryService : IMessageDeliveryService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Sends an sms message.
        /// </summary>
        /// <param name="from">From value, number or name depending on provider.</param>
        /// <param name="to">To number, destination phone number.</param>
        /// <param name="message">Text message.</param>
        /// <returns>Result of operation.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if one of parameters equals to null or empty string.</exception>
        Task<SMSSendResultCode> SendAsync(string from, string to, string message); 

        #endregion
    }
}
