﻿namespace ServerService
{
    #region GizmoClaimTypes
    /// <summary>
    /// Claim info types.
    /// </summary>
    public enum GizmoClaimTypes
    {
        #region SALE
        [ClaimDescription(@"Sale", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE")]
        Sale,

        [ClaimDescription(@"Sale", "CustomPrice", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_CUSTOM_PRICE", IsAssignable = false)]
        SaleCustomPrice,

        [ClaimDescription(@"Sale", "NonDefaultVat", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_NON_DEFAULT_VAT", IsAssignable = false)]
        SaleNonDefaultVat,

        [ClaimDescription(@"Sale", "PayLater", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_PAY_LATER")]
        SaleNonPayLater,

        [ClaimDescription(@"Sale", "VoidInvoices", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_INVOICES")]
        SaleNoVoidInvoices,

        [ClaimDescription(@"Sale", "Deposit", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_DEPOSIT")]
        Deposit,

        [ClaimDescription(@"Sale", "Withdraw", new GizmoClaimTypes[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_WITHDRAW")]
        Withdraw,

        [ClaimDescription(@"Sale", "DeleteTimePurchases", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_DELETE_TIME_PURCHASES")]
        SaleNoDeleteTimePurchases,

        [ClaimDescription(@"Sale", "ManualOpenCashDrawer", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_MANUAL_OPEN_CASH_DRAWER")]
        SaleManualOpenCashDrawer,
        #endregion

        #region SHIFT
        [ClaimDescription(@"Shift", "ViewExpected", "PERMISSION_GROUP_SHIFT", "PERMISSION_ACTION_SHIFT_VIEW_EXPECTED")]
        ShiftCountViewExpected,
        #endregion

        #region STOCK
        [ClaimDescription(@"Stock", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK")]
        Stock,
        #endregion

        #region MANAGEMENT

        [ClaimDescription(@"Management", "*", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT")]
        Management,

        [ClaimDescription(@"Management", "Tasks", new GizmoClaimTypes[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_TASKS", IsAssignable = false)]
        ManagementTasks,

        [ClaimDescription(@"Management", "Maintenance", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_MAINTENANCE")]
        ManageMaintenance,

        #endregion

        [ClaimDescription(@"Deployment", "*", "PERMISSION_GROUP_DEPLOYMENT", "PERMISSION_ACTION_DEPLOYMENT")]
        Deployment,

        [ClaimDescription(@"Monitoring", "*", "PERMISSION_GROUP_MONITORING", "PERMISSION_ACTION_MONITORING")]
        Monitoring,

        [ClaimDescription(@"Reports", "*", "PERMISSION_GROUP_REPORTS", "PERMISSION_ACTION_REPORTS")]
        Reports,

        [ClaimDescription(@"Settings", "*", "PERMISSION_GROUP_MAIN", "PERMISSION_ACTION_SERVER_SETTINGS")]
        ServerSettings,

        [ClaimDescription(@"Apps", "*", "PERMISSION_GROUP_APPLICATIONS", "PERMISSION_ACTION_APPLICATIONS")]
        Applications,

        [ClaimDescription(@"News", "*", "PERMISSION_GROUP_NEWS", "PERMISSION_ACTION_NEWS")]
        News,

        #region USER

        [ClaimDescription(@"User", "UserPasswordReset", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_PASSWORD_RESET")]
        UserResetPassword,

        [ClaimDescription(@"User", "UserEnable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ENABLE")]
        UserEnable,

        [ClaimDescription(@"User", "UserDisable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DISABLE")]
        UserDisable,

        [ClaimDescription(@"User", "UserManualLogin", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_MANUAL_LOGIN")]
        UserManualLogin,

        [ClaimDescription(@"User", "Delete", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DELETE")]
        UserDelete,

        [ClaimDescription(@"User", "ChangeUserName", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERNAME")]
        UserChangeUserName,

        [ClaimDescription(@"User", "ChangeUserGroup", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERGROUP")]
        UserChangeUserGroup,

        [ClaimDescription(@"User", "Edit", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_EDIT")]
        UserEdit,

        #endregion

        #region LOG

        [ClaimDescription(@"Log", "Clear", "PERMISSION_GROUP_LOG", "PERMISSION_ACTION_LOG_CLEAR")]
        LogClear,

        #endregion
    }
    #endregion

    #region BackupResultCode
    /// <summary>
    /// Backup result codes.
    /// </summary>
    public enum BackupResultCode
    {
        /// <summary>
        /// Backup succeeded.
        /// </summary>
        Sucess = 0,
        /// <summary>
        /// Database not initialized.
        /// </summary>
        NoInit = 1,
        /// <summary>
        /// Backup is already executing.
        /// </summary>
        AlreadyExecuting = 2,
        /// <summary>
        /// Backup failed.
        /// </summary>
        Failed = 3
    } 
    #endregion
}
