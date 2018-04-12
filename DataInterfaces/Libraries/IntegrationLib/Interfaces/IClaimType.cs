namespace IntegrationLib
{
    /// <summary>
    /// Claim type interface.
    /// </summary>
    public interface IClaimType
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets operation.
        /// </summary>
        string Operation { get; }

        /// <summary>
        /// Gets resource.
        /// </summary>
        string Resource { get; } 

        #endregion
    }
}
