using System;

namespace ServerService
{
    /// <summary>
    /// Gizmo claim description attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ClaimDescriptionAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ClaimDescriptionAttribute(string resource,
            string operation,
            string groupKey = null,
            string nameKey = null,
            string descriptionKey = null)
        {
            this.Resource = resource;
            this.Operation = operation;
            this.GroupKey = groupKey;
            this.NameKey = nameKey;
            this.DescriptionKey = descriptionKey;
        }

        public ClaimDescriptionAttribute(string resource,
            string operation,
            GizmoClaimTypes[] dependsOn,
            string groupKey = null,
            string nameKey = null,
            string descriptionKey = null)
        {
            this.Resource = resource;
            this.Operation = operation;
            this.GroupKey = groupKey;
            this.NameKey = nameKey;
            this.DescriptionKey = descriptionKey;
            this.DependsOn = dependsOn;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets resource.
        /// </summary>
        public string Resource
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets operation.
        /// </summary>
        public string Operation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets localized group key name.
        /// </summary>
        public string GroupKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets localized resource key name.
        /// </summary>
        public string NameKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets localized description key name.
        /// </summary>
        public string DescriptionKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets dependent claim type.
        /// </summary>
        public GizmoClaimTypes[] DependsOn
        {
            get; set;
        }

        /// <summary>
        /// Gets if permission is assignable.
        /// </summary>
        public bool IsAssignable
        {
            get; set;
        } = true;

        #endregion
    }
}
