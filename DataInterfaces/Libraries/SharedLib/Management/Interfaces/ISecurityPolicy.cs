using System;
using CoreLib;

namespace SharedLib
{
    #region ISecurityPolicy
    public interface ISecurityPolicy
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets security policy id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets security policy type.
        /// </summary>
        SecurityPolicyType Type { get; set; } 

        #endregion
    }
    #endregion

    #region SecurityPolicy
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
    #endregion
}
