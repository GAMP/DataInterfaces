using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// List item in the form required for the autocomplete control.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AutocompleteListItemDTO
    {
        /// <summary>
        /// Label of the item.
        /// </summary>
        [DataMember]
        public string label { get; set; }

        /// <summary>
        /// Value of the item.
        /// </summary>
        [DataMember]
        public string value { get; set; }
    }
}