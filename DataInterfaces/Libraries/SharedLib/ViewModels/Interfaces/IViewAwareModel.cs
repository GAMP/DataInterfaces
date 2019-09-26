namespace SharedLib.ViewModels
{
    /// <summary>
    /// Represents a view aware model.
    /// </summary>
    public interface IViewAwareModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets view.
        /// </summary>
        object View { get; }
        
        #endregion
    }
}
