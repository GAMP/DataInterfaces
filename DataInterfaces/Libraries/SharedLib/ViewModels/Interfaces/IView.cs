namespace SharedLib.Views
{
    /// <summary>
    /// Represents a view.
    /// </summary>
    public interface IView
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets the data context of the view.
        /// </summary>
        object DataContext { get; set; } 

        #endregion
    }
}
