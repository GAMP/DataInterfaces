using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Models
{
    /// <summary>
    /// Bundle.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class Bundle
    {
        /// <summary>
        /// Gets or sets bundle stock options.
        /// </summary>
        [DataMember()]
        public BundleStockOptionType BundleStockOptions
        {
            get; set;
        }
    }
}