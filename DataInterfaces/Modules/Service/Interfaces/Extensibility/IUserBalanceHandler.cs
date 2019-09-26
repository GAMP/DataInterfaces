using GizmoDALV2;
using System.Collections.Generic;

namespace ServerService
{
    /// <summary>
    /// User balance handler plugin interface.
    /// </summary>
    public interface IUserBalanceHandler
    {
        #region FUNCTIONS

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
