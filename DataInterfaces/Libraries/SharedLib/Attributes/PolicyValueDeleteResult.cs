namespace SharedLib
{
    /// <summary>
    /// Policy attribute delete value object.
    /// </summary>
    /// <remarks>
    /// Should be returned in order to signal policy code that the value should be deleted.
    /// </remarks>
    public struct PolicyValueDeleteResult
    {
        #region FIELDS
        public static PolicyValueDeleteResult _instance = new();
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Singelton value instance.
        /// </summary>
        public static PolicyValueDeleteResult Instance
        {
            get { return _instance; }
        }

        #endregion
    }
}
