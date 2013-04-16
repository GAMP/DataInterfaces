using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkinLib
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using System.Xml;
    using System.Windows.Media;
    using System.Windows;
    using System.Windows.Data;
    using System.ComponentModel;
    using System.Linq;
    using SkinInterfaces;
    using System.IO;
    using System.Reflection;
    using SkinLib;
    using SharedLib;

    /// <summary>
    /// Represents a bindable class used for main ui operations.
    /// </summary>
    public class UILayout : PropertyChangedNotificator, IUILayout
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance of layout.
        /// </summary>
        /// <remarks></remarks>
        public UILayout()
        {
        }

        /// <summary>
        /// Creates a new instance of layout.
        /// </summary>
        /// <param name="Configuration">UIConfiguration instance.</param>
        public UILayout(UIConfiguration Configuration)
            : this()
        {
            #region Validation
            if (Configuration == null)
                throw new ArgumentNullException("Configuration", "Layout configuration may not be null.");
            #endregion

            this.Configuration = Configuration;
        }

        /// <summary>
        /// Creates a new instance of layout from existing layout instance.
        /// </summary>
        /// <param name="Layout">Existing Layout instance</param>
        public UILayout(UILayout Layout)
            : this(Layout.Configuration)
        {
            this.Height = Layout.Height;
            this.Width = Layout.Width;
            this.IsDefault = Layout.IsDefault;
            this.ImagePath = Layout.ImagePath;
            this.Left = Layout.Left;
            this.Top = Layout.Top;
            this.XmlRepresentation = Layout.XmlRepresentation;
            this.ResolutionHeight = Layout.ResolutionHeight;
            this.ResolutionWidth = Layout.ResolutionWidth;
        }

        #endregion

        #region Fields
        private double
            width,
            height;
        private int
            resolutionWidth,
            resolutionHeight,
            left,
            top;
        private string
            configurationName,
            imagePath;
        private bool
            isDefault,
            mIsInitialized;
        protected ListCollectionView controlsView;
        private Brush backroundBrush;
        private XmlNode xmlRepresentation;
        private UIConfiguration configuration;
        #endregion

        #region Interface Properties
        IUIConfiguration IUILayout.Configuration
        {
            get { return this.Configuration; }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets wether current interface configuration is default.
        /// </summary>
        public bool IsDefault
        {
            get { return this.isDefault; }
            set
            {
                this.isDefault = value;
                this.RaisePropertyChanged("IsDefault");
            }
        }

        /// <summary>
        /// Gets resolution Width.
        /// </summary>
        public int ResolutionWidth
        {
            get { return this.resolutionWidth; }
            set
            {
                this.resolutionWidth = value;
                this.RaisePropertyChanged("ResolutionWidth");
            }
        }

        /// <summary>
        /// Gets resolution Height.
        /// </summary>
        public int ResolutionHeight
        {

            get { return this.resolutionHeight; }
            set
            {
                this.resolutionHeight = value;
                this.RaisePropertyChanged("ResolutionHeight");
            }
        }

        /// <summary>
        /// Gets or sets interface width.
        /// </summary>
        public double Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                this.RaisePropertyChanged("Width");
            }
        }

        /// <summary>
        /// Gets or sets interface height.
        /// </summary>
        public double Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                RaisePropertyChanged("Height");
            }
        }

        /// <summary>
        /// Gets or sets interface left position.
        /// </summary>
        public int Left
        {
            get { return this.left; }
            set
            {
                this.left = value;
                RaisePropertyChanged("Left");
            }
        }

        /// <summary>
        /// Gets or sets interface top position.
        /// </summary>
        public int Top
        {
            get { return this.top; }
            set
            {
                this.top = value;
                RaisePropertyChanged("Top");
            }
        }

        /// <summary>
        /// Gets user control collection view.
        /// </summary>
        public ListCollectionView UserControls
        {
            get
            {
                if (this.controlsView == null)
                {
                    this.controlsView = new ListCollectionView(this.Configuration.UserControls);
                    this.controlsView.Filter = new Predicate<object>(FilterMainControls);
                }
                return this.controlsView;
            }
        }

        /// <summary>
        /// Gets the collection of user controls in this configuration.
        /// </summary>
        public ReadOnlyCollection<FrameworkElement> Controls
        {
            get { return new ReadOnlyCollection<FrameworkElement>(this.Configuration.UserControls); }
        }

        /// <summary>
        /// Gets or sets the name of current configuration.
        /// </summary>
        public string Name
        {
            get { return this.configurationName; }
            set
            {
                this.configurationName = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the brush for the backgound.
        /// </summary>
        public Brush Background
        {
            get { return this.backroundBrush; }
            set
            {
                this.backroundBrush = value;
                RaisePropertyChanged("Background");
            }
        }

        /// <summary>
        /// Gets or sets the path to the background image for the current layout.
        /// </summary>
        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                this.imagePath = value;
                this.RaisePropertyChanged("ImagePath");
            }
        }

        /// <summary>
        /// Gets or sets XML Node representing the class.
        /// </summary>
        public XmlNode XmlRepresentation
        {
            get { return this.xmlRepresentation; }
            set
            {
                this.xmlRepresentation = value;
                this.RaisePropertyChanged("XmlRepresentation");
            }
        }

        /// <summary>
        /// Gets the parent configuration of this layout.
        /// </summary>
        public UIConfiguration Configuration
        {
            get { return this.configuration; }
            protected set
            {
                this.configuration = value;
                this.RaisePropertyChanged("Configuration");
            }
        }

        /// <summary>
        /// Gets if configuration was previously initialized.
        /// </summary>
        public bool IsInitialized
        {
            get { return this.mIsInitialized; }
            protected set
            {
                this.mIsInitialized = value;
                this.RaisePropertyChanged("IsInitialized");
            }
        }

        #endregion

        #region Functions

        #region Loading

        /// <summary>
        /// Loads the user controls from XML node.
        /// </summary>
        /// <remarks></remarks>
        public void Load()
        {
            XmlElement ElementNode = (XmlElement)this.XmlRepresentation.SelectSingleNode("UserControls");
            foreach (XmlElement ChildElementNode in ElementNode.ChildNodes)
            {
                //continue if no GUID specified
                if (ChildElementNode.HasAttribute("GUID") == false)
                    continue;
                //get GUID string
                string GUIDString = ChildElementNode.Attributes["GUID"].Value;
                //continue iof GUID is invalid
                if (!this.Configuration.IsValidGUID(GUIDString))
                    continue;
                //continue if no component exists
                if (!this.Configuration.HasComponent(GUIDString))
                    continue;
                //apply configuration
                if (this.Configuration.UserControlDictionary.ContainsKey(GUIDString))
                {
                    UserControl controlInstance = this.Configuration.UserControlDictionary[GUIDString] as UserControl;
                    if (controlInstance != null)
                        this.LoadUserElement(controlInstance, ChildElementNode);
                }
            }
            this.IsInitialized = true;
        }

        private void LoadUserElement(UserControl Element, XmlElement ElementNode)
        {
            #region Enums

            if (ElementNode.HasAttribute("Visibility"))
                Element.Visibility = (Visibility)Enum.Parse(typeof(Visibility), ElementNode.Attributes["Visibility"].Value);

            if (ElementNode.HasAttribute("HorizontalAlignment"))
                Element.HorizontalAlignment = (HorizontalAlignment)
                    Enum.Parse(typeof(HorizontalAlignment), ElementNode.Attributes["HorizontalAlignment"].Value);

            if (ElementNode.HasAttribute("VerticalAlignment"))
                Element.VerticalAlignment = (VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), ElementNode.Attributes["VerticalAlignment"].Value);

            #endregion

            #region Thickness
            if (ElementNode.HasAttribute("Margin"))
                Element.Margin = (Thickness)new ThicknessConverter().ConvertFromInvariantString(ElementNode.Attributes["Margin"].Value);

            #endregion

            #region Integers

            if (ElementNode.HasAttribute("ZIndex"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["ZIndex"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.ZIndexProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Row"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Row"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.RowProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Column"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Column"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.ColumnProperty, tempInt);
            }

            if (ElementNode.HasAttribute("ColumnSpan"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["ColumnSpan"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.ColumnSpanProperty, tempInt);
            }

            if (ElementNode.HasAttribute("RowSpan"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["RowSpan"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.RowSpanProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Top"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Top"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.TopProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Left"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Left"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.LeftProperty, tempInt);
            }

            #endregion

            #region Doubles

            //create shared converter
            DoubleConverter doubleConverter = new DoubleConverter();

            if (ElementNode.HasAttribute("Opacity"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Opacity"].Value).ToString(), out tempDouble))
                    Element.Opacity = tempDouble;
            }

            if (ElementNode.HasAttribute("Width"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Width"].Value).ToString(), out tempDouble))
                    Element.Width = tempDouble;
            }

            if (ElementNode.HasAttribute("Height"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Height"].Value).ToString(), out tempDouble))
                    Element.Height = tempDouble;
            }

            if (ElementNode.HasAttribute("MinHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MinHeight"].Value).ToString(), out tempDouble))
                    Element.MinHeight = tempDouble;
            }

            if (ElementNode.HasAttribute("MinWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MinWidth"].Value).ToString(), out tempDouble))
                    Element.MinWidth = tempDouble;
            }

            if (ElementNode.HasAttribute("MaxWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MaxWidth"].Value).ToString(), out tempDouble))
                    Element.MaxWidth = tempDouble;
            }

            if (ElementNode.HasAttribute("MaxHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MaxHeight"].Value).ToString(), out tempDouble))
                    Element.MaxHeight = tempDouble;
            }

            #endregion

            #region Dependency Properties
            foreach (FieldInfo Field in typeof(ExternalProperties).GetFields())
            {
                if (object.ReferenceEquals(Field.FieldType, typeof(DependencyProperty)))
                {
                    DependencyProperty CustomProperty = (DependencyProperty)Field.GetValue(null);
                    TypeConverter Converter = TypeDescriptor.GetConverter(CustomProperty.PropertyType);
                    if (ElementNode.HasAttribute(CustomProperty.Name))
                    {
                        Element.SetValue(CustomProperty, Converter.ConvertFrom(ElementNode.Attributes[CustomProperty.Name].Value));
                    }
                    else
                    {
                        Element.SetValue(CustomProperty, CustomProperty.DefaultMetadata.DefaultValue);
                    }
                }
            }
            #endregion
        }

        #endregion

        #region Saving

        /// <summary>
        /// Gets the XML representation of the layout.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public XmlNode ToXml()
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlElement XmlElement = XmlDoc.CreateElement("Layout");
            XmlDoc.AppendChild(XmlElement);
            XmlElement.SetAttribute("Name", this.Name);
            XmlElement.SetAttribute("ImagePath", this.ImagePath);
            XmlElement.SetAttribute("Width", new DoubleConverter().ConvertToInvariantString(this.Width.ToString()));
            XmlElement.SetAttribute("Height", new DoubleConverter().ConvertToInvariantString(this.Height));
            XmlElement.SetAttribute("IsDefault", this.IsDefault.ToString());
            XmlElement.SetAttribute("ResolutionWidth", new DoubleConverter().ConvertToInvariantString(this.ResolutionWidth));
            XmlElement.SetAttribute("ResolutionHeight", new DoubleConverter().ConvertToInvariantString(this.ResolutionHeight));
            XmlElement.SetAttribute("Left", this.Left.ToString());
            XmlElement.SetAttribute("Top", this.Top.ToString());
            XmlElement UserControlsElement = XmlDoc.CreateElement("UserControls");
            foreach (FrameworkElement Element in this.Configuration.UserControls)
            {
                XmlNode ElementXml = this.ToXml(Element);
                XmlNode ImportNode = XmlDoc.ImportNode(ElementXml, true);
                UserControlsElement.AppendChild(ImportNode);
            }
            XmlDoc.SelectSingleNode("Layout").AppendChild(UserControlsElement);
            return XmlDoc.FirstChild;
        }

        protected XmlNode ToXml(FrameworkElement ChildObject)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlElement ChildElement = XmlDoc.CreateElement(ChildObject.GetType().ToString());
            XmlDoc.AppendChild(ChildElement);

            #region Base attributes saving
            ChildElement.SetAttribute("Width", new DoubleConverter().ConvertToInvariantString(ChildObject.Width));
            ChildElement.SetAttribute("Height", new DoubleConverter().ConvertToInvariantString(ChildObject.Height));
            ChildElement.SetAttribute("HorizontalAlignment", ChildObject.HorizontalAlignment.ToString());
            ChildElement.SetAttribute("VerticalAlignment", ChildObject.VerticalAlignment.ToString());
            ChildElement.SetAttribute("Margin", new ThicknessConverter().ConvertToInvariantString(ChildObject.Margin));
            ChildElement.SetAttribute("Visibility", ChildObject.Visibility.ToString());
            ChildElement.SetAttribute("ZIndex", Canvas.GetZIndex(ChildObject).ToString());
            ChildElement.SetAttribute("Row", Grid.GetRow(ChildObject).ToString());
            ChildElement.SetAttribute("Column", Grid.GetColumn(ChildObject).ToString());
            ChildElement.SetAttribute("RowSpan", Grid.GetRowSpan(ChildObject).ToString());
            ChildElement.SetAttribute("ColumnSpan", Grid.GetColumnSpan(ChildObject).ToString());
            ChildElement.SetAttribute("Top", Canvas.GetTop(ChildObject).ToString());
            ChildElement.SetAttribute("Left", Canvas.GetLeft(ChildObject).ToString());
            ChildElement.SetAttribute("MinWidth", new DoubleConverter().ConvertToInvariantString(ChildObject.MinWidth));
            ChildElement.SetAttribute("MinHeight", new DoubleConverter().ConvertToInvariantString(ChildObject.MinHeight));
            ChildElement.SetAttribute("MaxWidth", new DoubleConverter().ConvertToInvariantString(ChildObject.MaxWidth));
            ChildElement.SetAttribute("MaxHeight", new DoubleConverter().ConvertToInvariantString(ChildObject.MaxHeight));
            if (((FrameworkElement)ChildObject).VisualState() == SkinInterfaces.ElementVisualState.Minimized)
            {
                ChildElement.SetAttribute("Opacity", ((FrameworkElement)ChildObject).RestoreVisuals().Opacity.ToString());
            }
            else
            {
                ChildElement.SetAttribute("Opacity", ChildObject.Opacity.ToString());
            }
            #endregion

            #region Dependency properties saving
            foreach (FieldInfo Field in typeof(ExternalProperties).GetFields())
            {
                if (object.ReferenceEquals(Field.FieldType, typeof(DependencyProperty)))
                {
                    DependencyProperty CustomProperty = (DependencyProperty)Field.GetValue(null);
                    //Check if object dependency property is set to default value 
                    object ObjectPropertyValue = ChildObject.GetValue(CustomProperty);
                    //Only save this property configuration if not set to default value
                    if (!(ObjectPropertyValue == CustomProperty.DefaultMetadata.DefaultValue))
                    {
                        ChildElement.SetAttribute(CustomProperty.Name, ObjectPropertyValue.ToString());
                    }
                }
            }
            #endregion

            return XmlDoc.FirstChild;
        }

        /// <summary>
        /// Accepts the current Layout.
        /// </summary>
        /// <remarks></remarks>
        public void Accept()
        {
            this.XmlRepresentation = this.ToXml();
            this.IsInitialized = false;
        }

        #endregion

        #endregion

        #region Component Filter
        private bool FilterMainControls(object Control)
        {
            if (Control is ICustomComponent)
            {
                return ((ICustomComponent)Control).Type == ComponentTypes.BaseControl;
            }
            else
            {
                return !(Control is Window);
            }
        }
        #endregion
    }
}
