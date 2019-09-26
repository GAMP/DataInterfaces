using SharedLib.Views;

namespace Manager.Views
{
    /// <summary>
    /// Manager About view interface.
    /// Implement this if you want to replace manager about window.
    /// </summary>
    /// <remarks>
    /// If multiple exports found with implementing this interface the firts export will be used.
    /// </remarks>
    public interface IManagerAboutView : IClosableView
    {
    }
}
