using System.ComponentModel;

namespace Client.ViewModels
{
    /// <summary>
    /// Client product order view model interface.
    /// </summary>
    public interface IProductOrderViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets point award.
        /// </summary>
        int Award { get; }

        /// <summary>
        /// Gets if order has award points.
        /// </summary>
        bool HasAward { get; }

        /// <summary>
        /// Gets selected payment method id.
        /// </summary>
        int? PaymentMethodId { get; }

        /// <summary>
        /// Gets payment methods.
        /// </summary>
        ICollectionView PaymentMethods { get; }

        /// <summary>
        /// Gets points total.
        /// </summary>
        int PointsTotal { get; set; }

        /// <summary>
        /// Gets if cash payment is required.
        /// </summary>
        bool RequiresCash { get; }

        /// <summary>
        /// Gets required points.
        /// </summary>
        bool RequiresPoints { get; }

        /// <summary>
        /// Gets order total.
        /// </summary>
        decimal Total { get; set; }

        /// <summary>
        /// Gets current user note.
        /// </summary>
        string UserNote { get; set; }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Sets current payment method.
        /// </summary>
        /// <param name="paymentMethodId">Payment method id.</param>
        /// <returns>True for sucess, otherwise false.</returns>
        bool SetPaymentMethod(int? paymentMethodId); 

        #endregion
    }
}