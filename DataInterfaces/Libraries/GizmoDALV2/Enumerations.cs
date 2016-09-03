using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoDALV2
{
    #region EntityEventType
    public enum EntityEventType
    {
        Added,
        Removed,
        Modified,
    }
    #endregion

    #region InvoiceErrorCode
    /// <summary>
    /// Invoice error codes.
    /// </summary>
    public enum InvoiceErrorCode
    {
        AlreadyPaid,
        PointsLess,
        PointsZero,
        CashZero,
        CashLess,
    } 
    #endregion

    #region PaymentErrorCode
    /// <summary>
    /// Payment error codes.
    /// </summary>
    public enum PaymentErrorCode
    {
        Unspecified = 0,
        InsufficientFunds = 1,
        AmountZero = 2,
        AmountReceivedLess = 3,
        InvalidPaymentMethod=4,
    }
    #endregion

    #region OrderStatusErrorCode
    /// <summary>
    /// Order status error codes.
    /// </summary>
    public enum OrderStatusErrorCode
    {
        Invoiced,
        Canceled,
    }
    #endregion

    #region DepositErrorCode
    /// <summary>
    /// Deposit transactions error codes.
    /// </summary>
    public enum DepositErrorCode
    {
        InsufficientFunds,
        InvalidPaymentMethod,
        NegativeBalanceNotAllowed,
    }
    #endregion

    #region StockErrorCodes
    public enum StockErrorCodes
    {
        /// <summary>
        /// Set when we try to modify stock level of a product that have stock disabled.
        /// </summary>
        StockDisabled,
        /// <summary>
        /// Set when we try to create a stock transaction with zero amount.
        /// </summary>
        ZeroAmount,
        /// <summary>
        /// Set when we have a TargetDifferentProduct flag on product stock option while not actually targeting specific product.
        /// </summary>
        TargetProductNotSet,
    } 
    #endregion
}
