namespace Client.ViewModels
{
    /// <summary>
    /// Client payment method view model interface.
    /// </summary>
    public interface IPaymentMethodViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets display order.
        /// </summary>
        int DisplayOrder { get; }

        /// <summary>
        /// Gets if method is built in.
        /// </summary>
        bool IsBuiltInMethod { get; }

        /// <summary>
        /// Gets localized name.
        /// </summary>
        string LocalizedName { get; }

        /// <summary>
        /// Gets payment method name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets payment method id.
        /// </summary>
        int? PaymentMethodId { get; }

        #endregion
    }
}