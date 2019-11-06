namespace CyClone.Core
{
    /// <summary>
    /// Buffer mannager implementation interface.
    /// </summary>
    public interface IBufferManager
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Returns existing buffer.
        /// </summary>
        /// <param name="buffer">Buffer instance.</param>
        void Return(byte[] buffer);

        /// <summary>
        /// Allocates buffer of specified size.
        /// </summary>
        /// <param name="minimumLength">Buffer size.</param>
        /// <returns>Allocated buffer that is at least <paramref name="minimumLength"/> in length.</returns>
        byte[] Rent(int minimumLength); 

        #endregion
    }
}
