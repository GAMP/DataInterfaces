using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client ordering data model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingData
    {
        #region FIELDS
        private IEnumerable<ClientOrderingProduct> products;
        private IEnumerable<ClientOrderingProductGroup> productGroups;
        private IEnumerable<ClientOrderingPaymentMethod> paymentMethods;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Product groups.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public IEnumerable<ClientOrderingProductGroup> ProductGroups
        {
            get
            {
                if (productGroups == null)
                    productGroups = new List<ClientOrderingProductGroup>();
                return productGroups;
            }
            set { productGroups = value; }
        }

        /// <summary>
        /// Products.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public IEnumerable<ClientOrderingProduct> Products
        {
            get
            {
                if (products == null)
                    products = new List<ClientOrderingProduct>();
                return products;
            }
            set { products = value; }
        }

        /// <summary>
        /// Payment methods.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public IEnumerable<ClientOrderingPaymentMethod> PaymentMethods
        {
            get
            {
                if (paymentMethods == null)
                    paymentMethods = new List<ClientOrderingPaymentMethod>();
                return paymentMethods;
            }
            set { paymentMethods = value; }
        }

        #endregion
    }
}
