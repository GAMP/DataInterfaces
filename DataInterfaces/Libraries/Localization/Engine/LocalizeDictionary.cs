using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using System.IO;
using CoreLib;

[assembly: XmlnsDefinition("http://schemas.root-project.org/xaml/presentation", "Localization.Engine")]
[assembly: XmlnsDefinition("http://schemas.root-project.org/xaml/presentation", "Localization.Extensions")]
[assembly: XmlnsPrefix("http://schemas.root-project.org/xaml/presentation", "lex")]

namespace Localization.Engine
{
    public sealed class LocalizeDictionary : DependencyObject
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Prevents a default instance of the <see cref="LocalizeDictionary"/> class from being created.
        /// Static Constructor
        /// </summary>
        private LocalizeDictionary()
        {
        }

        public LocalizeDictionary(string searchPath)
            : this()
        {
            SearchPath = searchPath;
        }

        #endregion

        #region FIELDS

        [DesignOnly(true)]
        public static readonly DependencyProperty DesignLanguageProperty =
            DependencyProperty.RegisterAttached(
            "DesignLanguage",
            typeof(string),
            typeof(LocalizeDictionary),
            new PropertyMetadata(SetDesignLanguageFromDependencyProperty));

        [DesignOnly(true)]
        public static readonly DependencyProperty DesignSearchPathProperty =
            DependencyProperty.RegisterAttached(
            "DesignSearchPath",
            typeof(string),
            typeof(LocalizeDictionary),
            new PropertyMetadata(SetDesignSearchPathFromDependencyProperty));

        /// <summary>
        /// Holds a SyncRoot to be thread safe
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Holds the instance of singleton
        /// </summary>
        private static LocalizeDictionary instance;

        private string language, searchPath, embededPath;

        private Dictionary<string, Dictionary<string, object>> dictionaries;

        private Dictionary<string, object> defaultDictionary;

        /// <summary>
        /// Get raised if the <see cref="LocalizeDictionary"/>.Culture is changed.
        /// </summary>
        internal event Action OnLanguageChanged;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the <see cref="LocalizeDictionary"/> singleton.
        /// If the underlying instance is null, a instance will be created.
        /// </summary>
        public static LocalizeDictionary Instance
        {
            get
            {
                // check if the underlying instance is null
                if (instance == null)
                {
                    // if it is null, lock the syncroot.
                    // if another thread is accessing this too, 
                    // it have to wait until the syncroot is released
                    lock (SyncRoot)
                    {
                        // check again, if the underlying instance is null
                        if (instance == null)
                        {
                            // create a new instance
                            instance = new LocalizeDictionary();
                        }
                    }
                }

                // return the existing/new instance
                return instance;
            }
        }

        /// <summary>
        /// Gets the default language.
        /// </summary>
        public static string DefaultLanguage
        {
            get { return "English"; }
        }

        /// <summary>
        /// Gets or sets current language.
        /// </summary>
        public string Language
        {
            get
            {
                if (string.IsNullOrWhiteSpace(language))
                    language = DefaultLanguage;
                return language;
            }

            set
            {
                language = value ?? throw new ArgumentNullException(nameof(Language));

                //raise language change
                RaiseLanguageChanged();
            }
        }

        /// <summary>
        /// Gets the default dictionary extension.
        /// </summary>
        public string FileExtension
        {
            get { return ".resx"; }
        }

        /// <summary>
        /// Gets or sets the path for dictionaries seacrh.
        /// </summary>
        public string SearchPath
        {
            get
            {
                return searchPath;
            }
            set
            {
                searchPath = value;

                //reset dictionaries
                ResourceDictionaries.Clear();

                //raise language change
                RaiseLanguageChanged();
            }
        }

        /// <summary>
        /// Gets or sets path to default embeded resource dictionary.
        /// </summary>
        public string DefaultResourcePath
        {
            get { return embededPath; }
            set
            {
                embededPath = value;

                //reset default dictionary
                DefaultDictionary = null;

                //raise language change
                RaiseLanguageChanged();
            }
        }

        /// <summary>
        /// Gets the resource dictionaries dictionary.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> ResourceDictionaries
        {
            get
            {
                if (dictionaries == null)
                    dictionaries = new Dictionary<string, Dictionary<string, object>>(StringComparer.InvariantCultureIgnoreCase);
                return dictionaries;
            }
        }

        /// <summary>
        /// Gets the defualt resource dictionary.
        /// </summary>
        public Dictionary<string, object> DefaultDictionary
        {
            get
            {
                if (defaultDictionary == null)
                {
                    if (!GetIsInDesignMode())
                    {
                        #region Validate
                        if (string.IsNullOrWhiteSpace(DefaultResourcePath))
                            return new Dictionary<string, object>();
                        #endregion

                        #region Get default dictionary
                        //get executable assembly
                        var exeAssembly = Assembly.GetEntryAssembly();

                        //open default resource stream in current assembly
                        using (Stream defaultStream = exeAssembly.GetManifestResourceStream(DefaultResourcePath))
                        {
                            //read embeded resource
                            defaultDictionary = LocalizeDictionary.TryLoadEmbededDictionary(defaultStream);
                        }

                        //throw exception if default dictionary cannot be loaded
                        if (defaultDictionary == null) { throw new ArgumentNullException("Default dictionary may not be null."); }
                        #endregion
                    }
                    else
                    {
                        defaultDictionary = new Dictionary<string, object>();
                    }
                }
                return defaultDictionary;
            }
            private set
            {
                defaultDictionary = value;
            }
        }

        #endregion

        #region FUNCTIONS

        #region Dependency Object

        [DesignOnly(true)]
        public static string GetDesignLanguage(DependencyObject obj)
        {
            if (Instance.GetIsInDesignMode())
            {
                return (string)obj.GetValue(DesignLanguageProperty);
            }
            else
            {
                return Instance.Language.ToString();
            }
        }

        [DesignOnly(true)]
        public static void SetDesignLanguage(DependencyObject obj, string value)
        {
            if (Instance.GetIsInDesignMode())
            {
                obj.SetValue(DesignLanguageProperty, value);
            }
        }

        [DesignOnly(true)]
        public static string GetDesignSearchPath(DependencyObject obj)
        {
            if (Instance.GetIsInDesignMode())
            {
                return (string)obj.GetValue(DesignSearchPathProperty);
            }
            else
            {
                return Instance.SearchPath;
            }
        }

        [DesignOnly(true)]
        public static void SetDesignSearchPath(DependencyObject obj, string value)
        {
            if (Instance.GetIsInDesignMode())
            {
                obj.SetValue(DesignSearchPathProperty, value);
            }
        }

        /// <summary>
        /// Attach an WeakEventListener to the <see cref="LocalizeDictionary"/>
        /// </summary>
        /// <param name="listener">The listener to attach</param>
        public void AddEventListener(IWeakEventListener listener)
        {
            // calls AddListener from the inline WeakCultureChangedEventManager
            WeakCultureChangedEventManager.AddListener(listener);
        }

        /// <summary>
        /// Gets the status of the design mode
        /// </summary>
        /// <returns>TRUE if in design mode, else FALSE</returns>
        public bool GetIsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(this);
        }

        /// <summary>
        /// Detach an WeakEventListener to the <see cref="LocalizeDictionary"/>
        /// </summary>
        /// <param name="listener">The listener to detach</param>
        public void RemoveEventListener(IWeakEventListener listener)
        {
            // calls RemoveListener from the inline WeakCultureChangedEventManager
            WeakCultureChangedEventManager.RemoveListener(listener);
        }

        /// <summary>
        /// Looks up the ResourceManagers for the searched <paramref name="resourceKey"/>
        /// with the passed culture. If the searched one does not exists with the passed culture, is will searched
        /// until the invariant culture is used.
        /// </summary>
        /// <param name="resourceDictionary">The dictionary to look up (e.g.: ResHelp, Resources, ...). NULL = Name of the default resource file (Resources)</param>
        /// <param name="resourceKey">The key of the searched entry (e.g.: <c>btnHelp</c>, Cancel, ...). NULL = Exception</param>
        /// <returns>
        /// TRUE if the searched one is found, otherwise FALSE
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// If the ResourceManagers cannot be looked up
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the searched <see cref="ResourceManager"/> wasn't found (only in runtime)
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the <paramref name="resourceKey"/> is null or empty
        /// </exception>
        public bool ResourceKeyExists(string resourceDictionary, string resourceKey)
        {
            try
            {
                return GetResourceDictionary(resourceDictionary).ContainsKey(resourceKey);
            }
            catch
            {
                if (GetIsInDesignMode())
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Callback function. Used to set the <see cref="LocalizeDictionary"/>.Culture if set in Xaml.
        /// Only supported at DesignTime.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="args">The event argument.</param>
        [DesignOnly(true)]
        private static void SetDesignLanguageFromDependencyProperty(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!Instance.GetIsInDesignMode())
            {
                return;
            }

            string language;

            try
            {
                language = (string)args.NewValue;
            }
            catch
            {
                if (Instance.GetIsInDesignMode())
                {
                    language = DefaultLanguage;
                }
                else
                {
                    throw;
                }
            }

            if (language != null)
            {
                Instance.Language = language;
            }
        }

        /// <summary>
        /// Callback function. Used to set the <see cref="LocalizeDictionary"/>.Culture if set in Xaml.
        /// Only supported at DesignTime.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="args">The event argument.</param>
        [DesignOnly(true)]
        private static void SetDesignSearchPathFromDependencyProperty(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!Instance.GetIsInDesignMode())
            {
                return;
            }

            string searchPath;

            try
            {
                searchPath = (string)args.NewValue;
            }
            catch
            {
                if (Instance.GetIsInDesignMode())
                {
                    searchPath = Environment.CurrentDirectory;
                }
                else
                {
                    throw;
                }
            }

            if (searchPath != null)
            {
                Instance.SearchPath = searchPath;
            }
        }

        /// <summary>
        /// Raises language change event.
        /// </summary>
        private void RaiseLanguageChanged()
        {
            OnLanguageChanged?.Invoke();
        }

        #endregion

        public TType GetLocalizedObject<TType>(string resourceKey) where TType : class
        {
            #region Validation
            if (string.IsNullOrEmpty(resourceKey))
            {
                if (GetIsInDesignMode())
                {
                    return null;
                }
                else
                {
                    if (resourceKey == null)
                    {
                        throw new ArgumentNullException(nameof(resourceKey));
                    }
                    else if (resourceKey == string.Empty)
                    {
                        throw new ArgumentException($"{nameof(resourceKey)} is empty", nameof(resourceKey));
                    }
                }
            }
            #endregion

            //get resource dictionary
            IDictionary<string, object> resourceDictionary = GetResourceDictionary(Language);

            object retVal = null;

            if (resourceDictionary != null && resourceDictionary.ContainsKey(resourceKey))
            {
                // gets the resourceobject with the choosen localization
                retVal = resourceDictionary[resourceKey] as TType;
            }
            else
            {
                if (DefaultDictionary.ContainsKey(resourceKey))
                {
                    retVal = DefaultDictionary[resourceKey];
                }
                else
                {
                    retVal = "INVALID_RESOURCE_KEY";
                }
            }

            return retVal as TType;
        }

        public TType GetLocalizedObject<TType>(Enum resourceKey) where TType : class
        {
            if (resourceKey.HasCustomAttribute<LocalizedAttribute>())
            {
                var attribute = resourceKey.GetAttributeOfType<LocalizedAttribute>();
                return GetLocalizedObject<TType>(attribute.ResourceKey);
            }
            else
            {
                return "UNLOCALIZED_RESOURCE" as TType;
            }
        }

        private IDictionary<string, object> GetResourceDictionary(string resourceDictionary)
        {
            if (!ResourceDictionaries.ContainsKey(resourceDictionary))
            {
                string fileSearchPath = string.IsNullOrWhiteSpace(SearchPath) ? Environment.CurrentDirectory : SearchPath;
                string filePath = resourceDictionary + FileExtension;
                string fullPath = Path.Combine(fileSearchPath, resourceDictionary + FileExtension);

                //load dictionary if exists 
                if (File.Exists(fullPath))
                {
                    //load dictionary
                    var loadedDictionary = LocalizeDictionary.TryLoadDictionary(fullPath);

                    //return default
                    if (loadedDictionary != null)
                    {
                        //add loaded dictionary to cache
                        ResourceDictionaries.Add(resourceDictionary, loadedDictionary);
                    }
                }
            }

            if (ResourceDictionaries.ContainsKey(resourceDictionary))
            {
                //return requested loaded dictionary
                return ResourceDictionaries[resourceDictionary];
            }
            else
            {
                return null;
            }
        }

        #region STATIC FUNCTIONS

        private static Dictionary<string, object> TryLoadDictionary(string resourceFileName)
        {
            if (string.IsNullOrWhiteSpace(resourceFileName))
                throw new ArgumentNullException(nameof(resourceFileName));

            try
            {
                var loadedDictionary = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
                using (var resourceStream = File.OpenRead(resourceFileName))
                {
                    using (var resourceReader = new ResXResourceReader(resourceStream))
                    {
                        var enumerator = resourceReader.GetEnumerator();

                        while (enumerator.MoveNext())
                        {
                            if (!loadedDictionary.ContainsKey(enumerator.Key.ToString()))
                                loadedDictionary.Add(enumerator.Key.ToString(), enumerator.Value);
                        }
                    }
                }

                return loadedDictionary;
            }
            catch
            {
                return null;
            }
        }

        private static Dictionary<string, object> TryLoadEmbededDictionary(Stream resourceStream)
        {
            if (resourceStream == null)
                throw new ArgumentNullException(nameof(resourceStream));

            try
            {
                var loadedDictionary = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

                using (var resourceReader = new ResourceReader(resourceStream))
                {
                    var enumerator = resourceReader.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        if (!loadedDictionary.ContainsKey(enumerator.Key.ToString()))
                            loadedDictionary.Add(enumerator.Key.ToString(), enumerator.Value);
                    }
                }

                return loadedDictionary;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region WeakCultureChangedEventManager
        /// <summary>
        /// This in line class is used to handle weak events to avoid memory leaks
        /// </summary>
        internal sealed class WeakCultureChangedEventManager : WeakEventManager
        {
            /// <summary>
            /// Indicates, if the current instance is listening on the source event
            /// </summary>
            private bool isListening;

            /// <summary>
            /// Holds the inner list of listeners
            /// </summary>
            private ListenerList listeners;

            /// <summary>
            /// Prevents a default instance of the <see cref="WeakCultureChangedEventManager"/> class from being created. 
            /// Creates a new instance of WeakCultureChangedEventManager
            /// </summary>
            private WeakCultureChangedEventManager()
            {
                // creates a new list and assign it to listeners
                listeners = new ListenerList();
            }

            /// <summary>
            /// Gets the singleton instance of <see cref="WeakCultureChangedEventManager"/>
            /// </summary>
            private static WeakCultureChangedEventManager CurrentManager
            {
                get
                {
                    // store the type of this WeakEventManager
                    Type managerType = typeof(WeakCultureChangedEventManager);

                    // try to retrieve an existing instance of the stored type
                    WeakCultureChangedEventManager manager = (WeakCultureChangedEventManager)GetCurrentManager(managerType);

                    // if the manager does not exists
                    if (manager == null)
                    {
                        // create a new instance of WeakCultureChangedEventManager
                        manager = new WeakCultureChangedEventManager();

                        // add the new instance to the WeakEventManager manager-store
                        SetCurrentManager(managerType, manager);
                    }

                    // return the new / existing WeakCultureChangedEventManager instance
                    return manager;
                }
            }

            /// <summary>
            /// Adds an listener to the inner list of listeners
            /// </summary>
            /// <param name="listener">The listener to add</param>
            internal static void AddListener(IWeakEventListener listener)
            {
                // add the listener to the inner list of listeners
                CurrentManager.listeners.Add(listener);

                // start / stop the listening process
                CurrentManager.StartStopListening();
            }

            /// <summary>
            /// Removes an listener from the inner list of listeners
            /// </summary>
            /// <param name="listener">The listener to remove</param>
            internal static void RemoveListener(IWeakEventListener listener)
            {
                // removes the listener from the inner list of listeners
                CurrentManager.listeners.Remove(listener);

                // start / stop the listening process
                CurrentManager.StartStopListening();
            }

            /// <summary>
            /// This method starts the listening process by attaching on the source event
            /// </summary>
            /// <param name="source">The source.</param>
            [MethodImpl(MethodImplOptions.Synchronized)]
            protected override void StartListening(object source)
            {
                if (!isListening)
                {
                    Instance.OnLanguageChanged += Instance_OnLanguageChanged;
                    isListening = true;
                }
            }

            /// <summary>
            /// This method stops the listening process by detaching on the source event
            /// </summary>
            /// <param name="source">The source to stop listening on.</param>
            [MethodImpl(MethodImplOptions.Synchronized)]
            protected override void StopListening(object source)
            {
                if (isListening)
                {
                    Instance.OnLanguageChanged -= Instance_OnLanguageChanged;
                    isListening = false;
                }
            }

            private void Instance_OnLanguageChanged()
            {
                // tells every listener in the list that the event is occurred
                DeliverEventToList(Instance, EventArgs.Empty, listeners);
            }

            /// <summary>
            /// This method starts and stops the listening process by attaching/detaching on the source event
            /// </summary>
            [MethodImpl(MethodImplOptions.Synchronized)]
            private void StartStopListening()
            {
                // check if listeners are available and the listening process is stopped, start it.
                // otherwise if no listeners are available and the listening process is started, stop it
                if (listeners.Count != 0)
                {
                    if (!isListening)
                    {
                        StartListening(null);
                    }
                }
                else
                {
                    if (isListening)
                    {
                        StopListening(null);
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}
