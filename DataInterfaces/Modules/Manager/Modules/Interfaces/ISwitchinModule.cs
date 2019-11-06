namespace Manager.Modules
{
    /// <summary>
    /// Switch in interface.
    /// Used for notification when application is switching to or out of the implementing module.
    /// </summary>
    /// <typeparam name="T">Module type.</typeparam>
    public interface ISwitchinModule<T>
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Called when applicaton switches to this module.
        /// </summary>
        /// <param name="previous">Previous module instance.</param>
        void OnSwitchingIn(T previous);

        /// <summary>
        /// Called when applicaton switches out of this module.
        /// </summary>
        /// <param name="current">Current module instance.</param>
        void OnSwitchingOut(T current); 

        #endregion
    }
}