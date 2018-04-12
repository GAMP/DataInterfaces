namespace SharedLib.User
{
    public interface IIntegratedUserProfile : IUserProfile
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets the time status of the profile.
        /// </summary>
        IUserTimeStatus TimeStatus { get; } 

        #endregion
    }
}
