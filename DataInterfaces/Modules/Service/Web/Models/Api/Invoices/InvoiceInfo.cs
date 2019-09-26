using SharedLib;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice info model.
    /// </summary>
    [DataContract()]
    public class InvoiceInfo : ResourceCreatedByInfo
    {
        #region FUNCTIONS

        /// <summary>
        /// Product order id.
        /// </summary>
        [DataMember()]
        public int ProductOrderId
        {
            get; set;
        }

        /// <summary>
        /// Invoice status.
        /// </summary>
        [DataMember()]
        public InvoiceStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Sub total amount.
        /// </summary>
        [DataMember()]
        public decimal SubTotal
        {
            get; set;
        }

        /// <summary>
        /// Total amount of points.
        /// </summary>
        [DataMember()]
        public int PointsTotal
        {
            get; set;
        }

        /// <summary>
        /// Total amount of tax.
        /// </summary>
        [DataMember()]
        public decimal TaxTotal
        {
            get; set;
        }

        /// <summary>
        /// Total amount.
        /// </summary>
        /// <remarks>
        /// This amount is sum of sub total and tax total.
        /// </remarks>
        [DataMember()]
        public decimal Total
        {
            get;
            set;
        }

        /// <summary>
        /// Outstanding amount.
        /// </summary>
        [DataMember]
        public decimal Outstanding
        {
            get;
            set;
        }

        /// <summary>
        /// Outstanding points.
        /// </summary>
        [DataMember()]
        public int OutstandngPoints
        {
            get; set;
        }

        /// <summary>
        /// Shift id.
        /// </summary>
        [DataMember()]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Register id.
        /// </summary>
        [DataMember()]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Indicates if invoice is voided.
        /// </summary>
        [DataMember()]
        public bool IsVoided
        {
            get; set;
        }

        #endregion
    }
}
