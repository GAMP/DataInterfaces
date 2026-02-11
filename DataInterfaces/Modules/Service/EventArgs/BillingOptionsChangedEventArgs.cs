using SharedLib;

namespace ServerService
{
    /// <summary>
    /// Billing option changed args.
    /// </summary>
    public sealed class BillingOptionsChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="options">Billing options.</param>
        public BillingOptionsChangedEventArgs(int userId, Gizmo.Web.Api.Models.BillingOption? options) : base(userId, UserChangeType.BillingOptions)
        {
            Options = options;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets billing options.
        /// </summary>
        public Gizmo.Web.Api.Models.BillingOption? Options
        {
            get;
        }
        #endregion
    }
}
