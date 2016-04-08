using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Modules
{
    /// <summary>
    /// IInitEnumerator interface.
    /// </summary>
    /// <remarks>
    /// When implemented OnEnumerate method will be called during initialization.
    /// </remarks>
    public interface IInitEnumerator
    {
        /// <summary>
        /// Initiates enumeration.
        /// </summary>
        void Enumerate();

        /// <summary>
        /// Initiates enumeration.
        /// </summary>
        Task EnumerateAsync();

        /// <summary>
        /// Clears any enumeration.
        /// </summary>
        void Clear();

        /// <summary>
        /// Clears any enumeration.
        /// </summary>
        Task ClearAsync();
    }
}
