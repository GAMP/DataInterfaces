namespace ServerService
{
    /// <summary>
    /// Claim info types.
    /// </summary>
    public enum GizmoClaimTypes
    {
        #region SALE
        /// <summary>
        /// Sale permission.
        /// </summary>
        [ClaimDescription(@"Sale", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE")]
        Sale,

        /// <summary>
        /// Sale at custom permission.
        /// </summary>
        [ClaimDescription(@"Sale", "CustomPrice", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_CUSTOM_PRICE")]
        SaleCustomPrice,

        /// <summary>
        /// Sale with non default vat permission.
        /// </summary>
        [ClaimDescription(@"Sale", "NonDefaultVat", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_NON_DEFAULT_VAT", IsAssignable = false)]
        SaleNonDefaultVat,

        /// <summary>
        /// Sale with pay later permission.
        /// </summary>
        [ClaimDescription(@"Sale", "PayLater", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_PAY_LATER")]
        SaleNonPayLater,

        /// <summary>
        /// Sale void invoice permission.
        /// </summary>
        [ClaimDescription(@"Sale", "VoidInvoices", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_INVOICES")]
        SaleNoVoidInvoices,

        /// <summary>
        /// Void used time invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "VoidUsedTimeInvoices", new GizmoClaimTypes[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_USED_TIME_INVOICES")]
        VoidUsedTimeInvoices,

        /// <summary>
        /// Void closed shift invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "VoidClosedShiftInvoices", new GizmoClaimTypes[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_CLOSED_SHIFT_INVOICES")]
        VoidClosedShiftInvoices,

        /// <summary>
        /// Void other operator invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "VoidOtherOperatorInvoices", new GizmoClaimTypes[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_OTHER_OPERATOR_INVOICES")]
        VoidOtherOperatorInvoices,

        /// <summary>
        /// Void previous business day invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "VoidPastDaysInvoices", new GizmoClaimTypes[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_PAST_DAYS_INVOICES")]
        VoidPastDaysInvoices,

        /// <summary>
        /// Sale deposit permission.
        /// </summary>
        [ClaimDescription(@"Sale", "Deposit", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_DEPOSIT")]
        Deposit,

        /// <summary>
        /// Sale withdraw permission.
        /// </summary>
        [ClaimDescription(@"Sale", "Withdraw", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_WITHDRAW")]
        Withdraw,

        /// <summary>
        /// View invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewInvoices", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_INVOICES")]
        ViewInvoices,

        /// <summary>
        /// View only unpaid invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewPaidInvoices", new GizmoClaimTypes[] { ViewInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAID_INVOICES")]
        ViewPaidInvoices,

        /// <summary>
        /// View only business day invoices permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewPastDaysInvoices", new GizmoClaimTypes[] { ViewInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_INVOICES")]
        ViewPastDaysInvoices,

        /// <summary>
        /// View deposits permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewDeposits", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_DEPOSITS")]
        ViewDeposits,

        /// <summary>
        /// View only business day deposits permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewPastDaysDeposits", new GizmoClaimTypes[] { ViewDeposits }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_DEPOSITS")]
        ViewPastDaysDeposits,

        /// <summary>
        /// View register transactions permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewRegisterTransactions", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_REGISTER_TRANSACTIONS")]
        ViewRegisterTransactions,

        /// <summary>
        /// View only business day register transactions permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ViewPastDaysRegisterTransactions", new GizmoClaimTypes[] { ViewRegisterTransactions }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_REGISTER_TRANSACTIONS")]
        ViewPastDaysRegisterTransactions,

        /// <summary>
        /// Sale delete time purchases permission.
        /// </summary>
        [ClaimDescription(@"Sale", "DeleteTimePurchases", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_DELETE_TIME_PURCHASES")]
        SaleNoDeleteTimePurchases,

        /// <summary>
        /// Sale manual open cash drawer permission.
        /// </summary>
        [ClaimDescription(@"Sale", "ManualOpenCashDrawer", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_MANUAL_OPEN_CASH_DRAWER")]
        SaleManualOpenCashDrawer,
        #endregion

        #region SHIFT
        /// <summary>
        /// Shift view expected permission.
        /// </summary>
        [ClaimDescription(@"Shift", "ViewExpected", "PERMISSION_GROUP_SHIFT", "PERMISSION_ACTION_SHIFT_VIEW_EXPECTED")]
        ShiftCountViewExpected,
        #endregion

        #region STOCK

        /// <summary>
        /// Stock permission.
        /// </summary>
        [ClaimDescription(@"Stock", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_ACCESS")]
        StockAccess,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [ClaimDescription(@"Stock", "Manage", new GizmoClaimTypes[] { StockAccess }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_MANAGE")]
        StockManage,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [ClaimDescription(@"Stock", "ViewStockTransactions", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_VIEW_STOCK_TRANSACTIONS")]
        ViewStockTransactions,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [ClaimDescription(@"Stock", "ViewPastDaysStockTransactions", new GizmoClaimTypes[] { ViewStockTransactions }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_VIEW_PAST_DAYS_STOCK_TRANSACTIONS")]
        ViewPastDaysStockTransactions,

        #endregion

        #region MANAGEMENT

        /// <summary>
        /// Management permission.
        /// </summary>
        [ClaimDescription(@"Management", "*", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT")]
        Management,

        /// <summary>
        /// Management access tasks permission.
        /// </summary>
        [ClaimDescription(@"Management", "Tasks", new GizmoClaimTypes[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_TASKS")]
        ManagementTasks,

        /// <summary>
        /// Management access processes permission.
        /// </summary>
        [ClaimDescription(@"Management", "Processes", new GizmoClaimTypes[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_PROCESSES")]
        ManageProcesses,

        /// <summary>
        /// Management access files permission.
        /// </summary>
        [ClaimDescription(@"Management", "Files", new GizmoClaimTypes[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_FILES")]
        ManageFiles,

        /// <summary>
        /// Management maintenance mode permission.
        /// </summary>
        [ClaimDescription(@"Management", "Maintenance", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_MAINTENANCE")]
        ManageMaintenance,

        /// <summary>
        /// Management security permission.
        /// </summary>
        [ClaimDescription(@"Management", "Security", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_SECURITY")]
        ManageSecurity,

        /// <summary>
        /// Management lock state permission.
        /// </summary>
        [ClaimDescription(@"Management", "LockState", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_LOCK_STATE")]
        ManageLockState,

        /// <summary>
        /// Management module restart permission.
        /// </summary>
        [ClaimDescription(@"Management", "ModuleRestart", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_MODULE_RESTART")]
        ManageModuleRestart,

        #endregion

        /// <summary>
        /// Deployment permission.
        /// </summary>
        [ClaimDescription(@"Deployment", "*", "PERMISSION_GROUP_DEPLOYMENT", "PERMISSION_ACTION_DEPLOYMENT")]
        Deployment,

        /// <summary>
        /// Monitoring permission.
        /// </summary>
        [ClaimDescription(@"Monitoring", "*", "PERMISSION_GROUP_MONITORING", "PERMISSION_ACTION_MONITORING")]
        Monitoring,

        /// <summary>
        /// Reports permission.
        /// </summary>
        [ClaimDescription(@"Reports", "*", "PERMISSION_GROUP_REPORTS", "PERMISSION_ACTION_REPORTS")]
        Reports,

        /// <summary>
        /// Server settings permission.
        /// </summary>
        [ClaimDescription(@"Settings", "*", "PERMISSION_GROUP_MAIN", "PERMISSION_ACTION_SERVER_SETTINGS")]
        ServerSettings,

        /// <summary>
        /// Applications permission.
        /// </summary>
        [ClaimDescription(@"Apps", "*", "PERMISSION_GROUP_APPLICATIONS", "PERMISSION_ACTION_APPLICATIONS")]
        Applications,

        /// <summary>
        /// News permission.
        /// </summary>
        [ClaimDescription(@"News", "*", "PERMISSION_GROUP_NEWS", "PERMISSION_ACTION_NEWS")]
        News,

        #region USER

        /// <summary>
        /// Reset user password permission.
        /// </summary>
        [ClaimDescription(@"User", "UserPasswordReset", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_PASSWORD_RESET")]
        UserResetPassword,

        /// <summary>
        /// Enable user permission.
        /// </summary>
        [ClaimDescription(@"User", "UserEnable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ENABLE")]
        UserEnable,

        /// <summary>
        /// Disable user permission.
        /// </summary>
        [ClaimDescription(@"User", "UserDisable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DISABLE")]
        UserDisable,

        /// <summary>
        /// Manual user login permission.
        /// </summary>
        [ClaimDescription(@"User", "UserManualLogin", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_MANUAL_LOGIN")]
        UserManualLogin,

        /// <summary>
        /// Delete user permission.
        /// </summary>
        [ClaimDescription(@"User", "Delete", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DELETE")]
        UserDelete,

        /// <summary>
        /// Change user name permission.
        /// </summary>
        [ClaimDescription(@"User", "ChangeUserName", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERNAME")]
        UserChangeUserName,

        /// <summary>
        /// Change user group permission.
        /// </summary>
        [ClaimDescription(@"User", "ChangeUserGroup", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERGROUP")]
        UserChangeUserGroup,

        /// <summary>
        /// Edit user permission.
        /// </summary>
        [ClaimDescription(@"User", "Edit", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_EDIT")]
        UserEdit,

        /// <summary>
        /// Edit user permission.
        /// </summary>
        [ClaimDescription(@"User", "AccessStats", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ACCESS_STATS")]
        UserAccessStats,

        #endregion

        #region LOG

        /// <summary>
        /// Access log permission.
        /// </summary>
        [ClaimDescription(@"Log", "*", "PERMISSION_GROUP_LOG", "PERMISSION_ACTION_LOG_ACCESS")]
        LogAccess,

        /// <summary>
        /// Clear log permission.
        /// </summary>
        [ClaimDescription(@"Log", "Clear", new GizmoClaimTypes[] { LogAccess }, "PERMISSION_GROUP_LOG", "PERMISSION_ACTION_LOG_CLEAR")]
        LogClear,

        #endregion

        #region WAITING_LINES

        /// <summary>
        /// Access waiting lines permission.
        /// </summary>
        [ClaimDescription(@"WaitingLines", "*", "PERMISSION_GROUP_WAITING_LINES", "PERMISSION_ACTION_WAITING_LINES_ACCESS")]
        WaitingLinesAccess,

        /// <summary>
        /// Manage waiting lines permission.
        /// </summary>
        [ClaimDescription(@"WaitingLines", "Manage", new GizmoClaimTypes[] { WaitingLinesAccess }, "PERMISSION_GROUP_WAITING_LINES", "PERMISSION_ACTION_WAITING_LINES_MANAGE")]
        WaitingLinesManage,

        #endregion

        #region REGISTER_TRANSACTIONS

        /// <summary>
        /// Create pay in register transactions permission.
        /// </summary>
        [ClaimDescription(@"RegisterTransactions", "RegisterTransactionsPayIn", "PERMISSION_GROUP_REGISTER_TRANSACTIONS", "PERMISSION_REGISTER_TRANSACTIONS_PAY_IN")]
        RegisterTransactionsPayIn,

        /// <summary>
        /// Create pay out register transactions permission.
        /// </summary>
        [ClaimDescription(@"RegisterTransactions", "RegisterTransactionsPayOut", "PERMISSION_GROUP_REGISTER_TRANSACTIONS", "PERMISSION_REGISTER_TRANSACTIONS_PAY_OUT")]
        RegisterTransactionsPayOut,

        #endregion

        #region WEB API
        [ClaimDescription(@"WebApi", "*", "PERMISSION_GROUP_WEB_API", "PERMISSION_ACTION_WEB_API")]
        WebApi,
        #endregion
    }
}
