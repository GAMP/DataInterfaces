using System;

namespace GizmoDALV2
{
    public interface IDbContextProvider<TContext> where TContext : IDisposable
    {
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
    }
}
