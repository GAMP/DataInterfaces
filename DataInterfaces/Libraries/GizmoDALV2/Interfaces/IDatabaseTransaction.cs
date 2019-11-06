using System;

namespace GizmoDALV2
{
    /// <summary>
    /// Database transaction implementation interface.
    /// </summary>
    public interface IDatabaseTransaction : IDisposable
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Commits transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back transaction.
        /// </summary>
        void Rollback(); 

        #endregion
    }
}
