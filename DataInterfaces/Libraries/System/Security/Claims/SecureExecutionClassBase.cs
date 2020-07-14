using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace System.Security.Claims
{
    /// <summary>
    /// Base class for claim based security.
    /// </summary>
    public abstract class SecureExecutionClassBase
    {
        #region STATIC FIELDS
        /// <summary>
        /// Static attribute type, cache it to improve performance.
        /// </summary>
        private static readonly Type attibuteType = typeof(ClaimsPrincipalPermissionAttribute);
        /// <summary>
        /// Attribute per type cache.
        /// List is used instead of IEnumerable to increase performance.
        /// </summary>
        private static readonly ConcurrentDictionary<int, List<ClaimsPrincipalPermissionAttribute>> cache = new ConcurrentDictionary<int, List<ClaimsPrincipalPermissionAttribute>>();
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isSecure">Indicates if security checks should be made upon class creation.</param>
        public SecureExecutionClassBase(bool isSecure = false)
        {
            if (isSecure)
            {
                //get type
                var type = GetType();

                //get type hash code
                var typeHashCode = type.GetHashCode();

                //get code security attributes
                var codeSecurityAttributes = cache.GetOrAdd(typeHashCode, (e) => type.GetCustomAttributes(attibuteType, true).OfType<ClaimsPrincipalPermissionAttribute>().ToList());

                //demand any required code security
                foreach (var pm in codeSecurityAttributes)
                    pm.Demand();
            }
        }
        #endregion
    }
}
