namespace SharedLib
{
    /// <summary>
    /// Inteface implemented by object supporting display order.
    /// </summary>
    public interface IDisplayOrder
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets display order.
        /// </summary>
        int DisplayOrder
        {
            get; set;
        }
        #endregion
    }
}
