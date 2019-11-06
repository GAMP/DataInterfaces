namespace IntegrationLib
{
    /// <summary>
    /// HTTP Credentials.
    /// </summary>
    public class HttpCredentials
    {
        #region Properties

        /// <summary>
        /// Gets credentials username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets credentials password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets if credentials are empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return string.IsNullOrWhiteSpace(Username) & string.IsNullOrWhiteSpace(Password); }
        }

        #endregion
    }
}
