namespace Manager
{
    public interface IMediaCapture
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Shows capture dialog.
        /// </summary>
        /// <param name="result">Result image.</param>
        /// <returns>True if sucessfully captured otherwise false.</returns>
        bool CaptureImage(out byte[] result); 

        #endregion
    }
}
