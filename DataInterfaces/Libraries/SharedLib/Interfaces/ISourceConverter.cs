namespace SharedLib
{
    /// <summary>
    /// Generic mapping inteface.
    /// </summary>
    /// <typeparam name="T">Destination type.</typeparam>
    public interface ISourceConverter<T>
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Converts to source class.
        /// </summary>
        /// <returns>Source class instance.</returns>
        T ToSource();

        /// <summary>
        /// Converts from source class.
        /// </summary>
        /// <param name="source">Source class instance.</param>
        void FromSource(T source); 

        #endregion
    }
}
