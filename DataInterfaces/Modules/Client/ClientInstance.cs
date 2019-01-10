namespace Client
{
    /// <summary>
    /// Provides access to the current Gizmo Client instance.
    /// </summary>
    public static class ClientInstance
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets current client instance.
        /// </summary>
        public static IClient Instance
        {
            get;
            set;
        } 

        #endregion
    }
}
