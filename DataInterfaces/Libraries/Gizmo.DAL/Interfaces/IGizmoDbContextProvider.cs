namespace Gizmo.DAL
{
    /// <summary>
    /// Database context provider interface.
    /// </summary>
    public interface IGizmoDbContextProvider //TODO: IDisposable?
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

        #endregion
    }
}
