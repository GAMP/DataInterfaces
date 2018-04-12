using GizmoDALV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// Handles user time billing.
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
        bool PreBillSession(int userId,
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

        /// <summary>
        /// Handles user balance calculation.
        /// </summary>
        /// <param name="userId">User id. If value equals null then all balances should be calculated.</param>
        /// <param name="hostGroupId">Host group id. Value can be null if balance calculated for unspecified host.</param>
        /// <param name="cx">Database context used by transaction.</param>
        /// <param name="currentState">Return value for balances.</param>
        /// <returns>True if balance calculation was handled otherwise false.
        /// If this function returns true then no further balance processing will occur and <paramref name="currentState"/> result will be returned to the caller.
        /// </returns>
        bool PreBalanceHandle(int? userId, int? hostGroupId, IGizmoDBContext cx, out Dictionary<int, UserBalance> currentState);

        /// <summary>
        /// Handles post user balance calculation.
        /// </summary>
        /// <param name="userId">User id. If value equals null then all balances should be calculated.</param>
        /// <param name="hostGroupId">Host group id. Value can be null if balance calculated for unspecified host.</param>
        /// <param name="cx">Database context used by transaction.</param>
        /// <param name="currentState">User balances previosly calculated.</param>
        void PostBalanceHandle(int? userId, int? hostGroupId, Dictionary<int, UserBalance> currentState, IGizmoDBContext cx); 

        #endregion
    }
}
