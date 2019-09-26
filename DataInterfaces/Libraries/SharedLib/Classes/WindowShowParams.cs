using System;
using System.Runtime.Serialization;
using System.Windows;

namespace SharedLib
{
    #region WindowShowParams
    /// <summary>
    /// Window creation and show parameters.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class WindowShowParams
    {
        #region CONSTRUCTOR

        public WindowShowParams()
        {
            this.StarupLocation = WindowStartupLocation.CenterOwner;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.AllowClosing = true;
            this.AllowDrag = true;
            this.ShowDialog = true;
            this.Icon = MessageBoxImage.Question;
            this.Buttons = MessageBoxButton.OK;
            this.TopMost = true;
        }

        public WindowShowParams(string title)
            : this()
        {
            this.Title = title;
        }

        public WindowShowParams(string title,
            double width = double.PositiveInfinity,
            double height = double.PositiveInfinity,
            int top = 0, int left = 0)
            : this(title)
        {
            this.Width = width;
            this.Height = height;
            this.Top = top;
            this.Left = left;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Window title.
        /// </summary>
        [DataMember()]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Left window position.
        /// </summary>
        [DataMember()]
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Top window position.
        /// </summary>
        [DataMember()]
        public int Top
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if window should be shown as dialog.
        /// </summary>
        [DataMember()]
        public bool ShowDialog
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if window should be topmost.
        /// </summary>
        [DataMember()]
        public bool TopMost
        {
            get;
            set;
        }

        /// <summary>
        /// Window width.
        /// </summary>
        [DataMember()]
        public double Width
        {
            get;
            set;
        }

        /// <summary>
        /// Window height.
        /// </summary>
        [DataMember()]
        public double Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets window owner.
        /// </summary>
        [IgnoreDataMember()]
        public IntPtr Owner
        {
            get;
            set;
        }

        /// <summary>
        ///Indicates if window will be draggable.
        /// </summary>
        [DataMember()]
        public bool AllowDrag
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if window buttons should be added.
        /// </summary>
        [DataMember()]
        public bool NoButtons
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if window closing is allowed.
        /// </summary>
        [DataMember()]
        public bool AllowClosing
        {
            get;
            set;
        }

        /// <summary>
        /// Window startup location.
        /// </summary>
        [DataMember()]
        public WindowStartupLocation StarupLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates size to content type.
        /// </summary>
        [DataMember()]
        public SizeToContent SizeToContent
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates buttons type.
        /// </summary>
        [DataMember()]
        public MessageBoxButton Buttons
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates icon image type.
        /// </summary>
        [DataMember()]
        public MessageBoxImage Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates keyboard default button.
        /// </summary>
        [DataMember()]
        public NotificationButtons DefaultButton { get; set; } = NotificationButtons.Ok;

        /// <summary>
        /// Indicates if window should be shown activated.
        /// </summary>
        [DataMember()]
        public bool ShowActivated
        {
            get;
            set;
        }

        /// <summary>
        /// Window maximum width.
        /// </summary>
        [DataMember()]
        public double MaxWidth { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// Window maximum height.
        /// </summary>
        [DataMember()]
        public double MaxHeight { get; set; } = double.PositiveInfinity;

        #endregion
    }
    #endregion
}
