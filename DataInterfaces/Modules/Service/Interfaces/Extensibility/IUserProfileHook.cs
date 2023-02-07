namespace ServerService
{
    /// <summary>
    /// Temporary inteface do not implement.
    /// </summary>
    public interface IUserProfileHook
    {
        #region FUNCTIONS
        /// <summary>
        /// Post create profile function.
        /// </summary>
        /// <param name="profile">Created profile.</param>
        void PostUserProfileCreate(Gizmo.IUserProfile profile); 
        #endregion
    }
}
