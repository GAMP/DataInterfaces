using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// An object containing a name and a decimal value.
    /// </summary>
    [Serializable]
    [DataContract]
    public class NamedDecimalContainerDTO
    {
        /// <summary>
        /// Name of the object.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Value of the object.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}