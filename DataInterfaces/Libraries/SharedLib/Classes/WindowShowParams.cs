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
        /// Gets the windows title.
        /// </summary>
        [DataMember()]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets left position.
        /// </summary>
        [DataMember()]
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets top position.
        /// </summary>
        [DataMember()]
        public int Top
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window should be shown as dialog.
        /// </summary>
        [DataMember()]
        public bool ShowDialog
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window should be topmost.
        /// </summary>
        [DataMember()]
        public bool TopMost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets window width.
        /// </summary>
        [DataMember()]
        public double Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets window height.
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
        public IntPtr Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window will be draggable.
        /// </summary>
        [DataMember()]
        public bool AllowDrag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window buttons should be added.
        /// </summary>
        [DataMember()]
        public bool NoButtons
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if window closing is allowed.
        /// </summary>
        [DataMember()]
        public bool AllowClosing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets startup location.
        /// </summary>
        [DataMember()]
        public WindowStartupLocation StarupLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets size to content type.
        /// </summary>
        [DataMember()]
        public SizeToContent SizeToContent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Messagebox buttons type.
        /// </summary>
        [DataMember()]
        public MessageBoxButton Buttons
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Messagebox icon image type.
        /// </summary>
        [DataMember()]
        public MessageBoxImage Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets keyboard default button.
        /// </summary>
        [DataMember()]
        public NotificationButtons DefaultButton { get; set; } = NotificationButtons.Ok;

        /// <summary>
        /// Gets or sets if window should be show activated.
        /// </summary>
        [DataMember()]
        public bool ShowActivated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets window maximum width.
        /// </summary>
        [DataMember()]
        public double MaxWidth { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// Gets or sets window maximum height.
        /// </summary>
        [DataMember()]
        public double MaxHeight { get; set;} = double.PositiveInfinity;

        #endregion
    }
    #endregion
}
