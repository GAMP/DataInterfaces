namespace ServerService.Services
{
    /// <summary>
    /// View localization service.
    /// </summary>
    public interface IViewLocalizerService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Get localized string value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns></returns>
        string GetLocalizedStringValue(string key); 

        #endregion
    }
}
