using CoreLib;
using System;

namespace SharedLib
{
    /// <summary>
    /// Security policy.
    /// </summary>
    [Serializable()]
    public class SecurityPolicy : ItemObject, ISecurityPolicy
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        public int ProfileId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets policy type.
        /// </summary>
        public SecurityPolicyType Type
        {
            get;
            set;
        }

        #endregion
    }
}
