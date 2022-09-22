namespace ServerService
{
    /// <summary>
    /// Mail Attachement.
    /// </summary>
    public sealed class MailAttachement
    {
        #region PROPERTIES
        
        /// <summary>
        /// Name of the attached file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Buffer of the attached file.
        /// </summary>
        public byte[] Data { get; set; } 

        #endregion

    }
}