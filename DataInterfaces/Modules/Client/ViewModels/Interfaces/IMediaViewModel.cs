using SkinInterfaces;

namespace Client.ViewModels
{
    /// <summary>
    /// Client media view model interface.
    /// </summary>
    public interface IMediaViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets exit full screen command.
        /// </summary>
        IExecutionChangedAwareCommand ExitFullScreenCommand { get; set; }

        /// <summary>
        /// Gets media source.
        /// </summary>
        string MediaSource { get; }

        /// <summary>
        /// Gets media source type.
        /// </summary>
        MediaSourceType SourceType { get; }

        #endregion
    }
}