namespace SharedLib
{
    /// <summary>
    /// Inteface implemented by object supporting checked state.
    /// </summary>
    public interface ICheckable
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets if item is checked.
        /// </summary>
        bool IsChecked
        {
            get; set;
        } 
        #endregion
    }
}
