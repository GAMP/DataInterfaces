namespace Manager.Services
{
    /// <summary>
    /// Composition service.
    /// </summary>
    public interface ICompositionService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets exported value.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <returns>Exported value.</returns>
        T GetExportedValue<T>(); 

        #endregion
    }
}