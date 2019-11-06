namespace Windows.UI.Notifications
{
    #region ToastAction
    /// <summary>
    /// Toast action.
    /// </summary>
    public class ToastAction
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets action arguments.
        /// </summary>
        public string Arguments
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets action content.
        /// </summary>
        public string Content
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets action image uri.
        /// </summary>
        public string ImageUri
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region ToastDismissalReasonProxy
    /// <summary>
    /// Toast dismissal proxy.
    /// </summary>
    public enum ToastDismissalReasonProxy
    {
        /// <summary>
        /// Cancelled by user.
        /// </summary>
        UserCanceled = 0,
        /// <summary>
        /// Application hidden.
        /// </summary>
        ApplicationHidden = 1,
        /// <summary>
        /// Timed out.
        /// </summary>
        TimedOut = 2
    }
    #endregion

    #region ToastTemplateTypeProxy
    /// <summary>
    /// Toast template proxy.
    /// </summary>
    public enum ToastTemplateTypeProxy
    {
        /// <summary>
        /// Image and text.
        /// </summary>
        ToastImageAndText01 = 0,
        /// <summary>
        /// Image and text.
        /// </summary>
        ToastImageAndText02 = 1,
        /// <summary>
        /// Image and text.
        /// </summary>
        ToastImageAndText03 = 2,
        /// <summary>
        /// Image and text.
        /// </summary>
        ToastImageAndText04 = 3,
        /// <summary>
        /// Text only.
        /// </summary>
        ToastText01 = 4,
        /// <summary>
        /// Text only.
        /// </summary>
        ToastText02 = 5,
        /// <summary>
        /// Text only.
        /// </summary>
        ToastText03 = 6,
        /// <summary>
        /// Text only.
        /// </summary>
        ToastText04 = 7
    }
    #endregion

    #region ToastNotificationPriorityProxy
    /// <summary>
    /// Toast notification priority proxy.
    /// </summary>
    public enum ToastNotificationPriorityProxy
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default = 0,

        /// <summary>
        /// High.
        /// </summary>
        High = 1
    } 
    #endregion

    #region ToastResult
    /// <summary>
    /// Toast result.
    /// </summary>
    public class ToastResult
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="arguments">Arguments.</param>
        /// <param name="dismissReason">Dismiss reason.</param>
        public ToastResult(string arguments, ToastDismissalReasonProxy? dismissReason)
        {
            Arguments = arguments;
            DismissReason = dismissReason;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets dismiss reason.
        /// </summary>
        public ToastDismissalReasonProxy? DismissReason
        {
            get; private set;
        }

        /// <summary>
        /// Gets result.
        /// </summary>
        public string Arguments
        {
            get; private set;
        }
        #endregion
    }
    #endregion
}
