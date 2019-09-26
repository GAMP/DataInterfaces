namespace Client.ViewModels
{
    /// <summary>
    /// Client shop view model interface.
    /// </summary>
    public interface IClientShopViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets order view model.
        /// </summary>
        IProductOrderViewModel Order { get; }

        #endregion
    }
}
