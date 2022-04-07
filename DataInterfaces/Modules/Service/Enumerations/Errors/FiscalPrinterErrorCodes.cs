using Localization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Fiscal printer error codes.
    /// </summary>
    public enum FiscalPrinterErrorCodes
    {
        /// <summary>
        /// Fiscal printer is not connected.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_NOT_CONNECTED")]
        NotConnected=0,
        /// <summary>
        /// Shift is expired.
        /// </summary>
        [Localized("FISCAL_PRINTER_SHIFT_EXPIRED")]
        ShiftExpired =1,
        /// <summary>
        /// Shift is closed.
        /// </summary>
        [Localized("FISCAL_PRINTER_SHIFT_CLOSED")]
        ShiftClosed =2,
    }
}
