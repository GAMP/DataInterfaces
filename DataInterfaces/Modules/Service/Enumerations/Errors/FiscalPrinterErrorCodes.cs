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
        NotConnected = 0,
        /// <summary>
        /// Shift is expired.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_SHIFT_EXPIRED")]
        ShiftExpired = 1,
        /// <summary>
        /// Shift is closed.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_SHIFT_CLOSED")]
        ShiftClosed = 2,
        /// <summary>
        /// Fiscal printer driver error.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_DRIVER_ERROR")]
        DriverError = 3,
        /// <summary>
        /// Fiscal printer error.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_PRINTER_ERROR")]
        PrinterError = 4,
        /// <summary>
        /// Failed to generate a receipt.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_RECEIPT_GENERATE_ERROR")]
        ReceiptGenerateError = 5,
        /// <summary>
        /// No itinital sale receipt was printed.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_NO_RECEIPT_ERROR")]
        NoReceipt = 6,
        /// <summary>
        /// Return receipt can't be generated since there are multiple tax systems.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_MULTIPLE_TAX_SYSTEMS")]
        MultipleTaxSystems = 7,
        /// <summary>
        /// Return receipt can't be generated since there are mixed deposits with other payment methods.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_DEPOSIT_MIXED")]
        DepositsMixedWithOtherPayments = 8,
        /// <summary>
        /// Return receipt can't be generated since there is a payment from deposits that doesn't match the amount of services.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_DEPOSIT_NOT_MATCH_SERVICES")]
        DepositsNotMatchServices = 9,
        /// <summary>
        /// Partially paid orders not allowed.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_PARTIAL_PAYMENT_NOT_ALLOWED")]
        PartiallyPaidNotAllowed =10,
        /// <summary>
        /// Mulitple payment methods not allowed.
        /// </summary>
        [Localized("FISCAL_PRINTER_ERROR_MULTIPLE_PAYMENT_METHODS_NOT_ALLOWED")]
        MultiplePaymentMethodsNotAllowed =11,
    }
}
