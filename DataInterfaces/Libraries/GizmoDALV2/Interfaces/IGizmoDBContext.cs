using System;
using System.Data;
using System.Linq;

namespace GizmoDALV2
{
    /// <summary>
    /// Gizmo Database context inteface.    
    /// </summary>
    /// <remarks>
    /// It is always safe to cast this interface to Entity Framework DbContext.
    /// </remarks>
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
        /// <returns>IQueryable Entity set.</returns>
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

        /// <summary>
        /// Demand find entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entityKey">Entity key.</param>
        /// <returns>Found entity.</returns>
        /// <exception cref="EntityNotFoundException">In case no entity found with given key.</exception>
        TEntity DemandFind<TEntity>(int entityKey);

        /// <summary>
        /// Demand find entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entityKeys">Entity keys.</param>
        /// <returns>Found entity.</returns>
        /// <exception cref="EntityNotFoundException">In case no entity found with given key.</exception>
        TEntity DemandFind<TEntity>(object[] entityKeys);

        /// <summary>
        /// Checks if credentials are valid.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <param name="salt">Salt.</param>
        /// <param name="pwdHash">Password hash.</param>
        /// <returns>True if valid otherwise false.</returns>
        bool CredentialsIsPasswordValid(string password, byte[] salt, byte[] pwdHash);

        /// <summary>
        /// Begins transaction.
        /// </summary>
        /// <returns>Database transaction.</returns>
        IDatabaseTransaction BeginTransaction();

        /// <summary>
        /// Begins transaction.
        /// </summary>
        /// <param name="isolationLevel">Transaction isolation level.</param>
        /// <returns>Database transaction.</returns>
        IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel);

        #endregion
    }
}
