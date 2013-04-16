using System;
using System.Windows.Media;
namespace GizmoShell
{
    #region IShellItemBase
    public interface IShellItemBase
    {
        /// <summary>
        /// Occours when item is updated.
        /// </summary>
        event EventHandler Update;
    } 
    #endregion

    #region IShellItemView
    /// <summary>
    /// Shell item view interface.
    /// </summary>
    public interface IShellItemView
    {
        ImageSource ExtraLargeIcon { get; }
        ImageSource JumboIcon { get; }
        ImageSource LargeIcon { get; }
        ImageSource SmallIcon { get; }
        void Refresh();
        string DisplayName { get; }
        string ToolTip { get; }
        bool IsMouseOver
        {
            get;
        }   
    } 
    #endregion
}
