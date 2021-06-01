using ServerService;
using System;
using System.Collections.Generic;

namespace Gizmo.Server.Web
{
    /// <summary>
    /// Temporary web api error code map.
    /// </summary>
    public static class ExceptionMap
    {
        #region CONSTANTS
        private const int defaultValue = 0;
        #endregion

        #region PRIVATE STATIC FIELDS
        private static readonly Dictionary<Type, int> _cache = new Dictionary<Type, int>()
        {
            {typeof(AssetErrorCode),7 },
            {typeof(BillingProfileErrorCode),8 },
            {typeof(DepositErrorCode),9 },
            {typeof(ReservationErrorCode),10 },
            {typeof(InvoiceErrorCode),11 },
            {typeof(InvoicePaymentErrorCode),12 },
            {typeof(OrderStatusErrorCode),13 },
            {typeof(PaymentErrorCode),14 },
            {typeof(PointTransactionErrorCode),15 },
            {typeof(ProductErrorCode),16 },
            {typeof(ShiftErrorCode),17 },
            {typeof(StockErrorCodes),18 },
            {typeof(UserGroupErrorCode),19 },
            {typeof(WaitingLineErrorCode),20 },
        };
        #endregion

        #region FUNCTIONS
        public static int GetErrorCode(Type t)
        {
            if (_cache.TryGetValue(t, out int value))
                return value;

            return defaultValue;
        } 
        #endregion
    }
}
