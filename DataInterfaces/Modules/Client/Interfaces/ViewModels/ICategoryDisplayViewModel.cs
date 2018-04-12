namespace Client.ViewModels
{
    #region ICategoryDisplayViewModel
    /// <summary>
    /// Category display view model.
    /// </summary>
    public interface ICategoryDisplayViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets category id.
        /// </summary>
        int CategoryId { get; }

        /// <summary>
        /// Gets or sets if is expanded.
        /// </summary>
        bool IsExpanded
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if selected.
        /// </summary>
        bool IsSelected
        {
            get; set;
        }

        /// <summary>
        /// Gets if category has apps.
        /// </summary>
        bool HasApps { get; }

        /// <summary>
        /// Gets parent id.
        /// </summary>
        int? ParentId { get; }

        #endregion
    } 
    #endregion
}
