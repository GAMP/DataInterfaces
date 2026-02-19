using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Take skip filter base.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class TakeSkipFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Take amount.
        /// </summary>
        [DataMember()]
        public int? Take
        {
            get; set;
        }

        /// <summary>
        /// Skip amount.
        /// </summary>
        [DataMember()]
        public int? Skip
        {
            get; set;
        } 
        
        #endregion
    }
}
