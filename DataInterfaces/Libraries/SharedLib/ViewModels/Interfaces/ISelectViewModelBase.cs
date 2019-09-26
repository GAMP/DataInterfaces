namespace SharedLib.ViewModels
{
    #region ISelectViewModelBase
    public interface ISelectViewModelBase : IValidateViewModelBase
    {
        /// <summary>
        /// Gets if modifications present.
        /// </summary>
        bool HasModifications
        {
            get;
        }

        /// <summary>
        /// Resets modifications.
        /// </summary>
        void ResetModifications();

        /// <summary>
        /// Used to process selection change event.
        /// </summary>
        void OnSelectionChanged(object sender, global::System.Windows.Controls.SelectionChangedEventArgs e);
    } 
    #endregion

    #region ISelectViewModel
    public interface ISelectViewModel : ISelectViewModelBase
    {
        /// <summary>
        /// Gets or sets selected item.
        /// </summary>
        object SelectedItem { get; set; }
    } 
    #endregion

    #region ISelectViewModelOfType
    public interface ISelectViewModelOfType<TItemType> : ISelectViewModelBase
    {
        /// <summary>
        /// Gets or sets selected item.
        /// </summary>
        TItemType SelectedItem { get; set; }
    } 
    #endregion        
}
