using System.Threading;

namespace System.Security.Claims
{
    /// <summary>
    /// Code security attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true, Inherited =true)]
    public sealed class CodeSecurityAttribute : Attribute
    {
        #region CONSTRCUTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="operation">Operation.</param>
        public CodeSecurityAttribute(string resource, string operation)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentNullException(nameof(resource));

            if (string.IsNullOrWhiteSpace(operation))
                throw new ArgumentNullException(nameof(operation));

            Resource = resource;
            Operation = operation;
        }
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets operation.
        /// </summary>
        public string Operation
        {
            get; set;
        }

        /// <summary>
        /// Gets resource.
        /// </summary>
        public string Resource
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
                if (identity.HasClaim(Resource, Operation) ==false)
                    throw new SecurityException();
            }
        }
        #endregion
    }
}
