using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml;
using System.IO;
using System.ComponentModel;
using SkinInterfaces;
using System.Diagnostics;

namespace SkinLib
{
    #region UIConfiguration
    [Serializable()]
    public class UIConfiguration : PropertyChangedNotificator, IUIConfiguration
    {
        #region Constructor

        /// <summary>
        /// Creates a new configuration instance.
        /// </summary>
        public UIConfiguration()
        {
        }

        /// <summary>
        /// Creates a new configuration instance from given configuration file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <remarks></remarks>
        public UIConfiguration(string fileName)
            : this()
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("FileName", "Configuration file name may not be null or empty");
            this.FileName = fileName;
        }

        #endregion

        #region Fields
        private ObservableCollection<UIComponent> components;
        private ObservableCollection<FrameworkElement> userControls;
        private ObservableCollection<UILayout> layouts;
        private ObservableCollection<string> assemblies;
        [NonSerialized()]
        private ObservableCollection<Exception> errors;
        [NonSerialized()]
        private Dictionary<string, UIComponent> componentsDictionary;
        [NonSerialized()]
        private Dictionary<string, FrameworkElement> userControlsDictionary;
        [NonSerialized()]
        protected Dictionary<string, UILayout> layoutDictionary;
        private string fileName;
        [NonSerialized()]
        private XmlNode xml;
        private UIComponent
            mainWindowComponent,
            controlBoxComponent,
            taskBarComponenet,
            applicationListComponent;
        #endregion

        #region Private Properties

        internal Dictionary<string, UIComponent> ComponentDictionary
        {
            get
            {
                if (this.componentsDictionary == null)
                    this.componentsDictionary = new Dictionary<string, UIComponent>();
                return this.componentsDictionary;
            }
        }

        internal Dictionary<string, FrameworkElement> UserControlDictionary
        {
            get
            {
                if (this.userControlsDictionary == null)
                    this.userControlsDictionary = new Dictionary<string, FrameworkElement>();
                return this.userControlsDictionary;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets file name.
        /// </summary>
        public string FileName
        {
            get { return this.fileName; }
            set
            {
                this.fileName = value;
                this.RaisePropertyChanged("FileName");
            }
        }

        /// <summary>
        /// Gets or sets the list of the components present in this configuration.
        /// </summary>
        public ObservableCollection<UIComponent> Components
        {
            get
            {
                if (this.components == null)
                    this.components = new ObservableCollection<UIComponent>();
                return this.components;
            }
        }

        /// <summary>
        /// Gets or sets configurations user controls instances.
        /// </summary>
        public ObservableCollection<FrameworkElement> UserControls
        {
            get
            {
                if (this.userControls == null)
                    this.userControls = new ObservableCollection<FrameworkElement>();
                return this.userControls;
            }
        }

        /// <summary>
        /// Gets the list of the assemblies assigned to this configuration.
        /// </summary>
        public ObservableCollection<string> Assemblies
        {
            get
            {
                if (this.assemblies == null)
                    this.assemblies = new ObservableCollection<string>();
                return this.assemblies;
            }
        }

        /// <summary>
        /// Gets errors occured durring initialization or loading.
        /// </summary>
        public ObservableCollection<Exception> Errors
        {
            get
            {
                if (this.errors == null)
                    this.errors = new ObservableCollection<Exception>();
                return this.errors;
            }
        }

        /// <summary>
        /// Gets or sets a list of the layouts present in this configuration.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObservableCollection<UILayout> Layouts
        {
            get
            {
                if (this.layouts == null)
                    this.layouts = new ObservableCollection<UILayout>();
                return this.layouts;
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the main window.
        /// </summary>
        public UIComponent MainWindowComponent
        {
            get
            {
                if (this.mainWindowComponent == null)
                    this.mainWindowComponent = new UIComponent(this);
                return this.mainWindowComponent;
            }
            set
            {
                this.mainWindowComponent = value;
                this.RaisePropertyChanged("MainWindowComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the control box.
        /// </summary>
        public UIComponent ControlBoxComponent
        {
            get
            {
                if (this.controlBoxComponent == null)
                    this.controlBoxComponent = new UIComponent(this);
                return this.controlBoxComponent;
            }
            set
            {
                this.controlBoxComponent = value;
                this.RaisePropertyChanged("ControlBoxComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the task bar.
        /// </summary>
        public UIComponent TaskBarComponent
        {
            get
            {
                if (this.taskBarComponenet == null)
                    this.taskBarComponenet = new UIComponent(this);
                return this.taskBarComponenet;
            }
            set
            {
                this.taskBarComponenet = value;
                this.RaisePropertyChanged("TaskBarComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the application list.
        /// </summary>
        public UIComponent ApplicationListComponent
        {
            get
            {
                if (this.applicationListComponent == null)
                    this.applicationListComponent = new UIComponent(this);
                return this.applicationListComponent;
            }
            set
            {
                this.applicationListComponent = value;
                this.RaisePropertyChanged("ApplicationListComponent");
            }
        }

        /// <summary>
        /// Gets or sets XML Node representing the class.
        /// </summary>
        public XmlNode Xml
        {
            get { return this.xml; }
            set
            {
                this.xml = value;
                this.RaisePropertyChanged("XmlRepresentation");
            }
        }

        #endregion

        #region Loading Functions

        public void Load()
        {
            #region INITIAL FILE LOAD

            XmlDocument configuration = new XmlDocument();
            configuration.Load(this.FileName);

            //clone initial configuration
            this.Xml = configuration.Clone();

            #endregion

            #region COMPONENTS

            //get components node
            var componentsNode = configuration.SelectSingleNode("Configuration/Components");

            //validate
            if (componentsNode == null)
                throw new ArgumentException("Skin components node not found in configuration file", "componentsNode");

            //load components
            this.LoadComponents(componentsNode);

            #endregion

            #region MODULES

            var modulesNode = configuration.SelectSingleNode("Configuration/Components/Modules");

            //validate
            if (componentsNode == null)
                throw new ArgumentException("Skin modules node not found in configuration file", "modulesNode");

            #region BUILT IN MODULES

            //temporary variable to hold component result
            UIComponent temComponent;

            #region MAINWINDOW

            var mainWindowNode = configuration.SelectSingleNode("Configuration/Components/Modules/MainWindow");

            //validate
            if (mainWindowNode == null)
                throw new ArgumentException("Main window node not found in configuration file", "componentsNode");

            //load main window
            if (this.TryLoadComponenet(mainWindowNode, out temComponent))
            {
                this.MainWindowComponent = temComponent;
            }

            #endregion

            #region TASKBAR

            var taskBarNode = (XmlElement)configuration.SelectSingleNode("Configuration/Components/Modules/TaskBar");

            //validate
            if (taskBarNode == null)
                throw new ArgumentException("Taskbar node not found in configuration file", "taskBarNode");

            if (this.TryLoadComponenet(taskBarNode, out temComponent))
            {
                this.TaskBarComponent = temComponent;
                this.InternalAdd(temComponent);
            }

            #endregion

            #region APPLIST

            var applicationListNode = (XmlElement)configuration.SelectSingleNode("Configuration/Components/Modules/ApplicationsList");

            //validate
            if (applicationListNode == null)
                throw new ArgumentException("ApplicationList node not found in configuration file", "applicationListNode");

            if (this.TryLoadComponenet(applicationListNode, out temComponent))
            {
                this.ApplicationListComponent = temComponent;
                this.InternalAdd(temComponent);
            }


            #endregion

            #region CONTROLBOX

            var controlBoxNode = (XmlElement)configuration.SelectSingleNode("Configuration/Components/Modules/ControlBox");

            //validate
            if (controlBoxNode == null)
                throw new ArgumentException("Control box node not found in configuration file", "controlBoxNode");

            if (this.TryLoadComponenet(controlBoxNode, out temComponent))
            {
                this.ControlBoxComponent = temComponent;
            }

            #endregion

            #endregion

            #endregion

            #region LAYOUTS

            var layoutsNode = configuration.SelectSingleNode("Configuration/Layouts");

            //validate
            if (layoutsNode == null)
                throw new ArgumentException("Skin layouts node not found in configuration file", "layoutsNode");

            this.LoadLayouts(layoutsNode);

            #endregion

            #region ASSEMBLIES

            var assembliesNode = configuration.SelectSingleNode("Configuration/Assemblies");

            //validate
            if (assembliesNode == null)
                throw new ArgumentException("Skin assemblies node not found in configuration file", "assembliesNode");

            this.LoadAssemblies(assembliesNode);

            #endregion
        }

        /// <summary>
        /// Loads the compoenents from given xml node.
        /// </summary>
        /// <param name="node">XML Node.</param>
        private void LoadComponents(XmlNode node)
        {
            #region VALIDATE
            if (node == null)
                throw new ArgumentNullException("node"); 
            #endregion

            #region CLEAR
            this.ComponentDictionary.Clear();
            this.Components.Clear(); 
            #endregion
           
            #region LOAD
            //get all child nodes excluding modules node
            foreach (XmlNode childNode in node.ChildNodes.Cast<XmlNode>().Where(x => String.Compare(x.Name, "Modules", true) != 0))
            {
                //check if node has any attributes
                if (childNode.Attributes == null || childNode.Attributes.Count == 0)
                    continue;

                UIComponent uiComponent;
                if (this.TryLoadComponenet(childNode, out uiComponent))
                {
                    //add to components list
                    this.InternalAdd(uiComponent);
                }
                else
                {
                    //add load error
                    this.Errors.Add(new Exception(String.Format("Could not load skin component from xml node {0}", childNode.OuterXml)));
                }
            } 
            #endregion
        }

        /// <summary>
        /// Loads the layouts from the XML node.
        /// </summary>
        private void LoadLayouts(XmlNode node)
        {
            #region VALIDATE
            if (node == null)
                throw new ArgumentNullException("node"); 
            #endregion

            #region CLEAR
            this.Layouts.Clear(); 
            #endregion

            #region LOAD
            foreach (XmlNode childNode in node.ChildNodes)
            {
                try
                {
                    //check if node has any attributes
                    if (childNode.Attributes == null || childNode.Attributes.Count == 0)
                        continue;

                    #region PROCESS EACH LAYOUT

                    //Create new configuration class                
                    UILayout layout = new UILayout(this);

                    //set xml
                    layout.Xml = childNode.Clone();

                    #region LAYOUT PROPERTIES

                    //Populate the class with xml data
                    if (childNode.Attributes["Height"] != null)
                    {
                        layout.Height = (double)new DoubleConverter().ConvertFromInvariantString(childNode.Attributes["Height"].Value);
                    }

                    if (childNode.Attributes["Width"] != null)
                    {
                        layout.Width = (double)new DoubleConverter().ConvertFromInvariantString(childNode.Attributes["Width"].Value);
                    }

                    if (childNode.Attributes["IsDefault"] != null)
                    {
                        layout.IsDefault = bool.Parse(childNode.Attributes["IsDefault"].Value);
                    }

                    if (childNode.Attributes["Left"] != null)
                    {
                        layout.Left = int.Parse(childNode.Attributes["Left"].Value);
                    }

                    if (childNode.Attributes["Top"] != null)
                    {
                        layout.Top = int.Parse(childNode.Attributes["Top"].Value.ToString());
                    }

                    if (childNode.Attributes["Name"] != null)
                    {
                        layout.Name = childNode.Attributes["Name"].Value.ToString();
                    }

                    if (childNode.Attributes["ResolutionWidth"] != null)
                    {
                        layout.ResolutionWidth = int.Parse(childNode.Attributes["ResolutionWidth"].Value);
                    }

                    if (childNode.Attributes["ResolutionHeight"] != null)
                    {
                        layout.ResolutionHeight = int.Parse(childNode.Attributes["ResolutionHeight"].Value);
                    }

                    if (childNode.Attributes["ImagePath"] != null)
                    {
                        layout.ImagePath = childNode.Attributes["ImagePath"].Value;
                    }

                    #endregion

                    //add to layouts collection
                    this.Layouts.Add(layout);

                    //set default name if required
                    if (String.IsNullOrWhiteSpace(layout.Name))
                        layout.Name = "UI Configuration " + this.Layouts.IndexOf(layout);

                    #endregion
                }
                catch (Exception ex)
                {
                    //add load error
                    this.Errors.Add(new Exception(String.Format("Could not load skin layout from xml node {0}", childNode.OuterXml), ex));
                }
            } 
            #endregion
        }

        /// <summary>
        /// Load the assemblies File Names from the configuration file.
        /// </summary>
        private void LoadAssemblies(XmlNode node)
        {
            #region VALIDATE
            if (node == null)
                throw new ArgumentNullException("node"); 
            #endregion

            #region CLEAR
            this.Assemblies.Clear(); 
            #endregion

            #region LOAD
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Attributes == null || childNode.Attributes.Count == 0)
                    continue;

                #region PROCESS EACH ASSEMBLY
                var fileNameAttribute = childNode.Attributes["FileName"];
                if (fileNameAttribute != null)
                {
                    string assemblyFileName = fileNameAttribute.Value;
                    this.Assemblies.Add(assemblyFileName);
                }
                #endregion
            } 
            #endregion
        }

        /// <summary>
        /// Tries to load a component from specifed xml node.
        /// </summary>
        /// <param name="node">XML node.</param>
        /// <param name="component">Loaded component.</param>
        /// <returns>True for sucessfull load, otherwise false.</returns>
        private bool TryLoadComponenet(XmlNode node, out UIComponent component)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            component = null;

            //check if there is attributes, if no attributes exists (eg invalid configuration or commented node) we cant proceed so return false
            if (node.Attributes == null || node.Attributes.Count == 0)
                return false;

            //check if all required parameters present
            if (node.Attributes["Assembly"] == null ||
                node.Attributes["Type"] == null ||
                node.Attributes["GUID"] == null)
            {
                return false;
            }

            //validate parameters
            if (!this.IsValidGUID(node.Attributes["GUID"].Value))
                return false;

            //create new ui component
            var uiComponent = new UIComponent(this);
            uiComponent.AssemblyName = node.Attributes["Assembly"].Value;
            uiComponent.Type = node.Attributes["Type"].Value;
            uiComponent.GUID = node.Attributes["GUID"].Value;

            if (node.Attributes["Title"] != null)
                uiComponent.Title = node.Attributes["Title"].Value;

            if (node.Attributes["Description"] != null)
                uiComponent.Description = node.Attributes["Description"].Value;

            //assign out value
            component = uiComponent;

            return true;
        }

        /// <summary>
        /// Saves the configuration to default file.
        /// </summary>
        public void Save()
        {
            this.Save(this.FileName);
        }

        /// <summary>
        /// Saves configuration to specified file.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Save(string fileName)
        {
            #region Create New XML Document
            XmlDocument xmlDocument = new XmlDocument();
            //create declaration node
            xmlDocument.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            //create root node
            XmlElement root = xmlDocument.CreateElement("Configuration");
            //set root attributes
            root.SetAttribute("Version", System.Windows.Forms.Application.ProductVersion);
            #endregion

            #region Add base nodes
            //create components node
            XmlNode componentsNode = xmlDocument.CreateElement("Components");

            //create assemblies node
            XmlNode assembliesNode = xmlDocument.CreateElement("Assemblies");

            //create layouts node
            XmlNode layoutsNode = xmlDocument.CreateElement("Layouts");
            #endregion

            #region Add Shell modules nodes
            XmlElement MainWindowNode = xmlDocument.CreateElement("Components/Modules/MainWindow");
            XmlElement ControlBox = xmlDocument.CreateElement("Components/Modules/ControlBox");
            XmlElement TaskBar = xmlDocument.CreateElement("Components/Modules/TaskBar");
            XmlElement AppList = xmlDocument.CreateElement("Components/Modules/ApplicationsList");
            #endregion

            #region Set components attributes
            foreach (UIComponent skinComponent in this.Components)
            {
                XmlElement componentNode = xmlDocument.CreateElement(skinComponent.Type);
                componentNode.SetAttribute("GUID", skinComponent.GUID);
                componentNode.SetAttribute("Type", skinComponent.Type);
                componentNode.SetAttribute("Assembly", skinComponent.AssemblyName);
                componentNode.SetAttribute("Title", skinComponent.Title);
                componentNode.SetAttribute("Description", skinComponent.Description);
                componentsNode.AppendChild(componentNode);
            }
            #endregion

            #region Add current layouts
            foreach (UILayout layout in this.Layouts)
            {
                if (layout.IsInitialized)
                    layout.Accept();
                XmlNode ImportedNode = xmlDocument.ImportNode(layout.Xml, true);
                layoutsNode.AppendChild(ImportedNode);
            }
            #endregion

            #region MODULES

            MainWindowNode.SetAttribute("GUID", this.MainWindowComponent.GUID);
            MainWindowNode.SetAttribute("Assembly", this.MainWindowComponent.AssemblyName);
            MainWindowNode.SetAttribute("Type", this.MainWindowComponent.Type);

            ControlBox.SetAttribute("GUID", this.ControlBoxComponent.GUID);
            ControlBox.SetAttribute("Assembly", this.ControlBoxComponent.AssemblyName);
            ControlBox.SetAttribute("Type", this.ControlBoxComponent.Type);

            TaskBar.SetAttribute("GUID", this.TaskBarComponent.GUID);
            TaskBar.SetAttribute("Assembly", this.TaskBarComponent.AssemblyName);
            TaskBar.SetAttribute("Type", this.TaskBarComponent.Type);

            AppList.SetAttribute("GUID", this.ApplicationListComponent.GUID);
            AppList.SetAttribute("Assembly", this.ApplicationListComponent.AssemblyName);
            AppList.SetAttribute("Type", this.ApplicationListComponent.Type);

            #endregion

            #region Add Assemblies
            foreach (string Assembly in this.Assemblies)
            {
                XmlElement AssemblyNode = xmlDocument.CreateElement("Assembly");
                AssemblyNode.SetAttribute("FileName", Assembly);
                assembliesNode.AppendChild(AssemblyNode);
            }
            #endregion

            #region Append Nodes
            root.AppendChild(componentsNode);
            root.AppendChild(layoutsNode);
            root.AppendChild(MainWindowNode);
            root.AppendChild(assembliesNode);
            xmlDocument.AppendChild(root);
            #endregion

            #region Save document
            xmlDocument.Save(fileName);
            #endregion
        }

        /// <summary>
        /// Checks if specified string is valid guid.
        /// </summary>
        /// <param name="guid">Guid string.</param>
        /// <returns>True or false.</returns>
        public bool IsValidGUID(string guid)
        {
            Guid temp;
            return !String.IsNullOrWhiteSpace(guid) && Guid.TryParse(guid, out temp);
        }

        /// <summary>
        /// Checks if the given component GUID exists in this configuration.
        /// </summary>
        public bool HasComponent(string guid)
        {
            return !String.IsNullOrWhiteSpace(guid) && this.ComponentDictionary.ContainsKey(guid);
        }

        /// <summary>
        /// Checks if configuration contains specified assembly file.
        /// </summary>
        /// <param name="assemblyFileName"></param>
        /// <returns>True if assembly exists, otherwise false.</returns>
        public bool HasAssembly(string assemblyFileName)
        {
            return this.Assemblies.Any(x => string.Compare(x, assemblyFileName, true) == 0);
        }

        /// <summary>
        /// Instanates configuration.
        /// </summary>
        public void Instanate()
        {
            this.UserControlDictionary.Clear();
            this.UserControls.Clear();
            foreach (var component in this.Components)
            {
                try
                {
                    var instance = UIHandler.Current.CreateInstance(component) as FrameworkElement;
                    if (instance != null && component.GUID != this.MainWindowComponent.GUID)
                    {
                        this.UserControlDictionary.Add(component.GUID, instance);
                        this.UserControls.Add(instance);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Adds UI component to internal collection.
        /// </summary>
        /// <param name="Componenet"></param>
        private void InternalAdd(UIComponent Componenet)
        {
            this.ComponentDictionary.Add(Componenet.GUID, Componenet);
            this.Components.Add(Componenet);
        }

        #endregion
    }
    #endregion
}
