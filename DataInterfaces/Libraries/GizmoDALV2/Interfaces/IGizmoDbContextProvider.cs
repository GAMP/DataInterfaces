using System.Threading.Tasks;

namespace GizmoDALV2
{
    /// <summary>
    /// Database GIZMO database context provider interface.
    /// </summary>
    public interface IGizmoDbContextProvider
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        IGizmoDBContext GetDbContext();

        /// <summary>
        /// Gets non-proxy database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        IGizmoDBContext GetDbNonProxyContext();

        /// <summary>
        /// Gets database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        Task<IGizmoDBContext> GetDbContextAsync();

        /// <summary>
        /// Gets non-proxy database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        Task<IGizmoDBContext> GetDbNonProxyContextAsync();

        #endregion
    }
}
