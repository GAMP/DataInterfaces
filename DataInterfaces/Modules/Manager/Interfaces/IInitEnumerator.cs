using System.Threading;
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
        #region FUNCTIONS
        
        /// <summary>
        /// Initiates enumeration.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        Task EnumerateAsync();

        /// <summary>
        /// Initiates enumeration.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task EnumerateAsync(CancellationToken ct);

        /// <summary>
        /// Clears enumeration.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task ClearAsync(CancellationToken ct);

        /// <summary>
        /// Clears any enumeration.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        Task ClearAsync(); 

        #endregion
    }
}
