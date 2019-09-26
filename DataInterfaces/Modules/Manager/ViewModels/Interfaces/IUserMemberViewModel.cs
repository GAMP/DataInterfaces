using SharedLib;

namespace Manager.ViewModels
{
    /// <summary>
    /// Member user view model interface.
    /// </summary>
    public interface IUserMemberViewModel : IUserViewModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets user group id.
        /// </summary>
        int GroupId { get; }

        /// <summary>
        /// Gets email.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Gets total amount of points.
        /// </summary>
        int Points { get; }

        /// <summary>
        /// Gets user deposits balance.
        /// </summary>
        decimal Deposits { get; }

        /// <summary>
        /// Gets if negative balance allowed.
        /// </summary>
        bool? IsNegativeBalanceAllowed { get; }

        /// <summary>
        /// Gets user session state.
        /// </summary>
        SessionState SessionState { get; }

        /// <summary>
        /// Gets total user session span.
        /// </summary>
        double SessionSpan { get; }

        /// <summary>
        /// Gets total user session active span.
        /// </summary>
        double SessionActiveSpan { get; } 

        /// <summary>
        /// Gets current user session slot.
        /// </summary>
        int? Slot { get; }

        /// <summary>
        /// Gets if user represents an guest.
        /// </summary>
        bool IsGuest { get; }

        #endregion
    }
}
