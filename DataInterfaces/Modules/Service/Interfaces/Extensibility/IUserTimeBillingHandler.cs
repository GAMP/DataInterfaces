using GizmoDALV2;
using System;

namespace ServerService
{
    /// <summary>
    /// User billing plugin interface.
    /// </summary>
    public interface IUserTimeBillingHandler
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Handles user billing.
        /// </summary>
        /// <param name="userId">User id of billed user.</param>
        /// <param name="spanSeconds">Span in seconds to be billed.</param>
        /// <param name="isNegativeAllowed">Indicates if user negative balance is allowed either by user group or explicitly for the user.</param>
        /// <param name="creditLimit">User credit limit.</param>
        /// <param name="userSessionId">User session being billed.</param>
        /// <param name="hostGroupId">Host group id.</param>
        /// <param name="userGroupId">User group id.</param>
        /// <param name="billProfileId">User bill profile id.</param>
        /// <param name="currentTime">Time of billing execution.</param>
        /// <param name="cx">Database context.</param>
        /// <param name="logout">Indicates if user should be logout.</param>
        /// <returns>True if was handled otherwise false.</returns>
        bool BillSession(int userId,
           double spanSeconds,
           bool isNegativeAllowed,
           decimal creditLimit,
           int userSessionId,
           int? hostGroupId,
           int? userGroupId,
           int? billProfileId,
           DateTime currentTime,
           IGizmoDBContext cx,
           out bool logout);

        #endregion
    }
}
