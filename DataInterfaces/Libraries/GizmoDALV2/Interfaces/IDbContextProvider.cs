using System;

namespace GizmoDALV2
{
    /// <summary>
    /// Database context provider interface.
    /// </summary>
    /// <typeparam name="TContext">Context type.</typeparam>
    public interface IDbContextProvider<TContext> where TContext : IDisposable
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        TContext GetDbContext();

        /// <summary>
        /// Gets non-proxy database context.
        /// </summary>
        /// <returns>New context instance.</returns>
        TContext GetDbNonProxyContext(); 

        #endregion
    }
}
