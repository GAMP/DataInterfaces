namespace SharedLib.Applications
{
    public interface IItemVisualOptions
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Gets or sets if accessible.
        /// </summary>
        bool Accessible { get; set; }

        /// <summary>
        /// Gets or sets caption.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets image data.
        /// </summary>
        byte[] ImageData { get; set; } 

        #endregion
    }
}
