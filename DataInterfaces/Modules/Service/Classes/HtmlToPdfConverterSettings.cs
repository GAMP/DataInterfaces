namespace ServerService
{
    /// <summary>
    /// Class which represents the settings of rendering engine.
    /// </summary>
    public class HtmlToPdfConverterSettings
    {
        /// <summary>
        /// Initializes a new instance of the HtmlToPdfConverterSettings class.
        /// </summary>
        public HtmlToPdfConverterSettings()
        {
            //Set page margins
            this.Margin = new PdfMargins() { All = 0 };

            //Set page orientation
            this.Orientation = PdfPageOrientation.Portrait;

            //Enable Javascript
            this.EnableJavaScript = true;
            //Enable Hyperlink
            this.EnableHyperLink = false;
            //Enable Form
            this.EnableForm = false;

            //Split text 
            this.SplitTextLines = false;
            //Split Image
            this.SplitImages = false;

            //Set additional delay
            this.AdditionalDelay = 2000;
        }

        /// <summary>
        /// Gets or sets enable form; If it is enabled then HTML form fields are converted
        /// to PDF form fields in the generated PDF document. The default value is false.
        /// </summary>
        public bool EnableForm { get; set; }

        /// <summary>
        /// Gets or sets the additional delay to load JavaScript; Unit is Milliseconds;
        /// </summary>
        public int AdditionalDelay { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to preserve the live-links in the converted
        /// document or not;
        /// </summary>
        public bool EnableHyperLink { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to Enable/Disable JavaScripts in the
        /// webpage;
        /// </summary>
        public bool EnableJavaScript { get; set; }

        /// <summary>
        /// Gets or sets the margins to the PDF document;
        /// </summary>
        public PdfMargins Margin { get; set; }

        /// <summary>
        /// Gets or sets the Orientation of the PDF document;
        /// </summary>
        public PdfPageOrientation Orientation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [split text lines].
        /// </summary>
        public bool SplitTextLines { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [split images].
        /// </summary>
        public bool SplitImages { get; set; }
    }
        
    /// <summary>
    /// Enumerator that represents the PDF page orientations. Default value is Portrait.
    /// </summary>
    public enum PdfPageOrientation
    {
        /// <summary>
        /// Portrait orientation.
        /// </summary>
        Portrait = 0,

        /// <summary>
        /// Landscape orientation.
        /// </summary>
        Landscape = 1
    }

    /// <summary>
    /// A class representing PDF page margins.
    /// </summary>
    public class PdfMargins
    {
        /// <summary>
        /// Initializes a new instance of the PdfMargins class.
        /// </summary>
        public PdfMargins()
        {
            this.All = 40;
        }

        /// <summary>
        /// Gets or sets the left margin size. Default value: 40 pixels
        /// </summary>
        public float Left { get; set; }

        /// <summary>
        /// Gets or sets the top margin size. Default value: 40 pixels
        /// </summary>
        public float Top { get; set; }
        
        /// <summary>
        /// Gets or sets the right margin size. Default value: 40 pixels
        /// </summary>
        public float Right { get; set; }

        /// <summary>
        /// Gets or sets the bottom margin size. Default value: 40 pixels
        /// </summary>
        public float Bottom { get; set; }

        /// <summary>
        /// Sets margin of each side of the page. Default value: 40 pixels
        /// </summary>
        public float All
        {
            set
            {
                this.Left = value;
                this.Top = value;
                this.Right = value;
                this.Bottom = value;
            }
        }

    }

}