using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingData
    {
        #region FIELDS
        private IEnumerable<UserProductDTO> products;
        private IEnumerable<UserProductGroupDTO> productGroups;
        private IEnumerable<UserPaymentMethodDTO> paymentMethods;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets product groups.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public IEnumerable<UserProductGroupDTO> ProductGroups
        {
            get
            {
                if (productGroups == null)
                    productGroups = new List<UserProductGroupDTO>();
                return productGroups;
            }
            set { productGroups = value; }
        }

        /// <summary>
        /// Gets or sets products.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public IEnumerable<UserProductDTO> Products
        {
            get
            {
                if (products == null)
                    products = new List<UserProductDTO>();
                return products;
            }
            set { products = value; }
        }

        /// <summary>
        /// Gets or sets payment methods.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public IEnumerable<UserPaymentMethodDTO> PaymentMethods
        {
            get
            {
                if (paymentMethods == null)
                    paymentMethods = new List<UserPaymentMethodDTO>();
                return paymentMethods;
            }
            set { paymentMethods = value; }
        }

        #endregion
    }
}
