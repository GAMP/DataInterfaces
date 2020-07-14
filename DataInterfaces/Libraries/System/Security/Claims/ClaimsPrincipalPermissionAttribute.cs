using System.Security.Permissions;
using System.Threading;

namespace System.Security.Claims
{
    /// <summary>
    /// Code security attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClaimsPrincipalPermissionAttribute : Attribute
    {
        #region CONSTRCUTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="action">Security action.</param>
        public ClaimsPrincipalPermissionAttribute(SecurityAction action)
        {
            Action = action;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="operation">Operation.</param>
        public ClaimsPrincipalPermissionAttribute(string resource, string operation) : this(SecurityAction.Assert, resource, operation)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="action">Security action.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="operation">Operation.</param>
        public ClaimsPrincipalPermissionAttribute(SecurityAction action, string resource, string operation)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentNullException(nameof(resource));

            if (string.IsNullOrWhiteSpace(operation))
                throw new ArgumentNullException(nameof(operation));

            Action = action;
            Resource = resource;
            Operation = operation;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets operation.
        /// </summary>
        public string Operation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets resource.
        /// </summary>
        public string Resource
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets action.
        /// </summary>
        public SecurityAction Action
        {
            get; set;
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Demands required claim.
        /// </summary>
        /// <exception cref="SecurityException">thrown if claim demand cannot be met.</exception>
        public void Demand()
        {
            //get current principal
            if (Thread.CurrentPrincipal is ClaimsPrincipal identity)
            {
                //check if required claim is present
                if (identity.HasClaim(Resource, Operation) == false)
                    throw new SecurityException();
            }
        }
        #endregion
    }
}
