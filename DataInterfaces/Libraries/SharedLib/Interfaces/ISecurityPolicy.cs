using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLib;

namespace SharedLib
{
    #region ISecurityPolicy
    public interface ISecurityPolicy
    {
        int Id { get; set; }
        int ProfileId { get; set; }
        global::CoreLib.SecurityPolicyType Type { get; set; }
    }
    #endregion

    #region SecurityPolicy
    [Serializable()]
    public class SecurityPolicy : ItemObject, ISecurityPolicy
    {
        #region Properties

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
