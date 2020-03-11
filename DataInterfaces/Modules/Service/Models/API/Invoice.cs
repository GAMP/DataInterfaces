using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class Invoice : ModifiableByWithRequiredUserMemberBase
    {
        #region Invoice

        /// <summary>
        /// Gets or sets product order id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ProductOrderId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public InvoiceStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets invoice sub total amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal SubTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total amount of points.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int PointsTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets invoice total amount of tax.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal TaxTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total amount.
        /// </summary>
        /// <remarks>
        /// This amount is sum of sub total and tax total.
        /// </remarks>
        [DataMember()]
        [ProtoMember(6)]
        public decimal Total
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets outstanding amount.
        /// </summary>
        [DataMember]
        [ProtoMember(7)]
        public decimal Outstanding
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets outstanding points.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int OutstandngPoints
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if invoice is voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public bool IsVoided
        {
            get; set;
        }

        /// <summary>
        /// Gets payments maid against this invoice.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public IEnumerable<InvoicePayment> InvoicePayments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets invoice lines.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public IEnumerable<InvoiceLine> InvoiceLines
        {
            get; set;
        }

        /// <summary>
        /// Gets voids.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public IEnumerable<VoidInvoice> Voids
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets product order.
        /// </summary>
        [DataMember()]
        [ProtoMember(15, AsReference = true)]
        public ProductOrder ProductOrder
        {
            get; set;
        }

        #endregion

    }
}
