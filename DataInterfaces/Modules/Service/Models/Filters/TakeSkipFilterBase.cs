using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class TakeSkipFilterBase
    {
        #region PROPERTIES

        [DataMember()]
        public int? Take
        {
            get; set;
        }

        [DataMember()]
        public int? Skip
        {
            get; set;
        } 
        
        #endregion
    }
}
