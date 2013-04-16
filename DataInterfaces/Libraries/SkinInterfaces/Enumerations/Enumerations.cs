using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkinInterfaces
{
    #region ComponentTypes
    /// <summary>
    /// Custom Control type numeration.
    /// </summary>
    [Flags()]
    public enum ComponentTypes : int
    {
        BaseControl = 0,
        Gadget = 1,
    } 
    #endregion

    #region BindingSources
    /// <summary>
    /// Availiable data sources enumeration.
    /// </summary>
    [Flags()]
    public enum BindingSources : int
    {
        None = 0,
        Users = 1,
        Applications = 2,
        ApplicationStats = 4,
        SQServers = 16,
        Rss = 32,
        Desktop = 64,
        TaskBar = 128,
        SystemTray = 256,
        MediaLibrary = 512,
        ViewModel = 1024,
        UserProfile = 2048,
    } 
    #endregion
    
    #region ElementVisualState
    /// <summary>
    /// Represent visual state of our custom control or window.
    /// When changing this states the skin engine can react and perform the action needed to respond to the change.
    /// </summary>
    [Flags()]
    public enum ElementVisualState : int
    {
        /// <summary>
        /// This value is set when control is in normal state.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// This value is set when control is maximized.
        /// </summary>
        Maximized = 2,
        /// <summary>
        /// This value is set when control is minimized.
        /// </summary>
        Minimized = 4,
        /// <summary>
        /// This value is set when control is closed.
        /// </summary>
        Closed = 8,
    } 
    #endregion

    #region RestoreType
    /// <summary>
    /// Restore visuals type enumeration.
    /// </summary>
    public enum RestoreType : int
    {
        None = 0,
        Width = 1,
        Height = 2,
        Margins = 4,
        Opacity = 8,
    } 
    #endregion

    #region HostAdornerState
    /// <summary>
    /// Represents Host Adorner States.
    /// </summary>
    public enum HostAdornerState : sbyte
    {
        /// <summary>
        /// With this state Host Ardoner will only apper on the event of Adorned Element.
        /// </summary>
        Event,
        /// <summary>
        /// With this state Host Ardoner will always be visible over the Adorned Element.
        /// </summary>
        Always,
    } 
    #endregion

    #region DesktopItemViewType
    /// <summary>
    /// Desktop item type enumeration.
    /// </summary>
    public enum DesktopItemViewType
    {
        /// <summary>
        /// View is virtual.
        /// </summary>
        Virtual,
        /// <summary>
        /// View is file or virtual file.
        /// </summary>
        File,
    } 
    #endregion

    #region MarginConverterParams
    public enum MarginConverterParams : int
    {
        Top = 0,
        Bottom = 1,
        Left = 2,
        Right = 3,
    }
    #endregion
}
