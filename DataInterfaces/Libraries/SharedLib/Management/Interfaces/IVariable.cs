namespace SharedLib.Management
{
    /// <summary>
    /// Variable implementation interface.
    /// </summary>
    public interface IVariable
    {
        #region PROPERTIES
        
        /// <summary>
        /// Id.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Full name.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Scope.
        /// </summary>
        ModuleScopes Scope { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        string Value { get; set; } 

        #endregion
    }
}
