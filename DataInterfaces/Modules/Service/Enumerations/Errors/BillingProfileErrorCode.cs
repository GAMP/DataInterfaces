namespace ServerService
{
    /// <summary>
    /// Billing profile error codes.
    /// </summary>
    public enum BillingProfileErrorCode
    {
        /// <summary>
        /// Set when we try to create a rate step to an invalid minute.
        /// </summary>
        InvalidMinute = 0,

        /// <summary>
        /// Set when we try to create a rate with multiple loop steps.
        /// </summary>
        MultipleLoops = 1,
    }
}
