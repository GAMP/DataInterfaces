using System;
using System.Linq;

namespace GizmoDALV2
{
    /// <summary>
    /// Gizmo Database context inteface.    
    /// </summary>
    public interface IGizmoDBContext :IDisposable
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if entity events should be cached.
        /// </summary>
        bool IsEventsCached
        {
            get;set;
        }
        
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets queryable db set for specified type.
        /// </summary>
        /// <typeparam name="TEntity">Entiity type.</typeparam>
        /// <returns>Entity set.</returns>
        IQueryable<TEntity> QueryableSet<TEntity>() where TEntity : class;
        
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        int SaveChanges(); 

        #endregion
    }
}
