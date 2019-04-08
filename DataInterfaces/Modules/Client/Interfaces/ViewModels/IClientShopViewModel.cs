namespace Client.ViewModels
{
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
