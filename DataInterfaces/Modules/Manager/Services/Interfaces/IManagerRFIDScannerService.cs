using System.Threading;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// RFID Scanner service.
    /// </summary>
    public interface IManagerRFIDScannerService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets RFID Readers names.
        /// </summary>
        /// <returns>Array of name strings.</returns>
        string[] GetReaderNames();

        /// <summary>
        /// Reads first found SmartCard UID.
        /// </summary>
        /// <param name="ct">Cancellation Token.</param>
        /// <returns>First found UID, null in case read was unsuccessful.</returns>
        Task<byte[]> ReadCurrentCardUIDAsync(CancellationToken ct); 

        #endregion
    }
}
