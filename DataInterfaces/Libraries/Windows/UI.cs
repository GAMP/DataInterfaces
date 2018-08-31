namespace Windows.UI.Notifications
{
    #region ToastAction
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
    public enum ToastDismissalReasonProxy
    {
        UserCanceled = 0,
        ApplicationHidden = 1,
        TimedOut = 2
    }
    #endregion

    #region ToastTemplateTypeProxy
    public enum ToastTemplateTypeProxy
    {
        ToastImageAndText01 = 0,
        ToastImageAndText02 = 1,
        ToastImageAndText03 = 2,
        ToastImageAndText04 = 3,
        ToastText01 = 4,
        ToastText02 = 5,
        ToastText03 = 6,
        ToastText04 = 7
    }
    #endregion

    #region ToastNotificationPriorityProxy
    public enum ToastNotificationPriorityProxy
    {
        Default = 0,
        High = 1
    } 
    #endregion

    #region ToastResult
    public class ToastResult
    {
        #region CONSTRUCTOR
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
