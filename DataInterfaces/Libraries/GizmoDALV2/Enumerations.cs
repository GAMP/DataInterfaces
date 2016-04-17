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
}
