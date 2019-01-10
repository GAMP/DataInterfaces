using ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Claim type base type.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ClaimTypeBase : IClaimType
    {
        #region CONSTRUCTOR
        public ClaimTypeBase(string resource, string operation)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentNullException(nameof(resource));

            if (string.IsNullOrWhiteSpace(operation))
                throw new ArgumentNullException(nameof(operation));

            this.Resource = resource;
            this.Operation = operation;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets resource.
        /// </summary>
        [DataMember()]
        public virtual string Resource
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets operation.
        /// </summary>
        [DataMember()]
        public virtual string Operation
        {
            get; protected set;
        }

        #endregion

        #region FUNCTIONS

        public static IEnumerable<IClaimType> GetClaimTypes()
        {
            return Enum.GetValues(typeof(GizmoClaimTypes))
                .OfType<GizmoClaimTypes>()
                .Select(x =>
                {
                    var claimAttribute = CoreLib.EnumeratorExtension.GetAttributeOfType<ClaimDescriptionAttribute>(x);
                    var info = new ClaimTypeBase(claimAttribute.Resource, claimAttribute.Operation);
                    return info;
                });
        }

        #endregion
    }
}
