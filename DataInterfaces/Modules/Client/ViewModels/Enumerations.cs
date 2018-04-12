namespace Client.ViewModels
{
    #region RatingFilterType
    /// <summary>
    /// Rating filter type.
    /// </summary>
    public enum RatingFilterType
    {
        Any = 0,
        Plus1 = 1,
        Plus2 = 2,
        Plus3 = 3,
        Plus4 = 4,
        Five = 5,
        Unrated = 6,
    }
    #endregion

    #region LoginProgressState
    public enum LoginProgressState : int
    {
        Initial = 0,
        Login = 1,
        Failed = 2,
        Logout = 3,
    }
    #endregion

    #region AppSort
    public enum AppSort
    {
        Title,
        Rating,
        Use,
        DateAdded,
        ReleaseDate,
    } 
    #endregion
}
