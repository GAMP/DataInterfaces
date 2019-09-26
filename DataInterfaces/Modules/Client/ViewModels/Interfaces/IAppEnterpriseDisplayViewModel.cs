namespace Client.ViewModels
{
    /// <summary>
    /// Client app enterprise display view model interface.
    /// </summary>
    public interface IAppEnterpriseDisplayViewModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets enterprise id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets enterprise name.
        /// </summary>
        string Name { get; } 

        #endregion
    }
}