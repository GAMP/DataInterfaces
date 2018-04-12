namespace IntegrationLib
{
    /// <summary>
    /// License Key interface.
    /// </summary>
    public interface IApplicationLicenseKey
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the keys string representation.
        /// </summary>
        string KeyString { get; }

        /// <summary>
        /// Returns if the key value is valid.
        /// </summary>
        bool IsValid { get; }

        #endregion
    }
}
