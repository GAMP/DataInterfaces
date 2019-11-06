namespace Manager.Views
{
    /// <summary>
    /// User module main view.
    /// </summary>
    public interface IUserModuleMainView : IViewColumns
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Scrolls to selected user.
        /// </summary>
        void ScrollToSlected(); 

        #endregion
    }  
}
