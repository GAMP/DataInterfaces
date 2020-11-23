using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable]
    [DataContract]
    public class PaginationFilter
    {
        private const int DEFAULT_LIMIT = 10;
        private const int MAX_LIMIT = 100;

        private int limit = DEFAULT_LIMIT;

        /// <summary>
        /// Return records after the specified id.
        /// </summary>
        [DataMember]
        public int? StartingAfter { get; set; }

        /// <summary>
        /// Return records before the specified id.
        /// </summary>
        [DataMember]
        public int? EndingBefore { get; set; }

        /// <summary>
        /// Limit the number of records to return.
        /// </summary>
        [DataMember]
        public int Limit
        {
            get
            {
                return limit;
            }
            set
            {
                if (value <= 0)
                    limit = DEFAULT_LIMIT;

                if (value > MAX_LIMIT)
                    limit = MAX_LIMIT;

                if (value > 0 && value <= MAX_LIMIT)
                    limit = value;
            }
        }
    }
}