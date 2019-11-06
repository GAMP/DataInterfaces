using System;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Claim info base class.
    /// Used to describe existing claims.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ClaimTypeInfoBase : ClaimTypeBase, IClaimTypeInfo
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="operation">Operation.</param>
        public ClaimTypeInfoBase(string resource, string operation) : base(resource, operation)
        {
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets group.
        /// </summary>
        [DataMember()]
        public string Group
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [DataMember()]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [DataMember()]
        public virtual string Description
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        [DataMember()]
        public virtual Enum Type
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets dependent claim.
        /// </summary>
        [DataMember()]
        public virtual Enum[] DependsOn
        {
            get; set;
        }

        #endregion        
    }
}
