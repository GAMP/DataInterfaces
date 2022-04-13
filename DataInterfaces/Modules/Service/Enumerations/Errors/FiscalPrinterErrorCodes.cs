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
        [Localized("FISCAL_PRINTER_ERROR_SHIFT_EXPIRED")]
        ShiftExpired =1,
        /// <summary>
        /// Shift is closed.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_SHIFT_CLOSED")]
        ShiftClosed =2,
        /// <summary>
        /// Fiscal printer driver error.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_DRIVER_ERROR")]
        DriverError =3,
        /// <summary>
        /// Fiscal printer error.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_PRINTER_ERROR")]
        PrinterError =4,
        /// <summary>
        /// Failed to generate a receipt.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_RECEIPT_GENERATE_ERROR")]
        ReceiptGenerateError =5,
    }
}
