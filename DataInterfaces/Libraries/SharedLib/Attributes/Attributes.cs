using System;
using System.Linq.Expressions;

namespace SharedLib
{
    #region RoleAssignableAttribute
    /// <summary>
    /// Role assignable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RoleAssignableAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="assignable">Indicates if role is assignable.</param>
        public RoleAssignableAttribute(bool assignable)
        {
            Assignable = assignable;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if role is assignable.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region CanUserAssignAttribute
    /// <summary>
    /// User assignable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CanUserAssignAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="assignable">Indicates if user assignable.</param>
        public CanUserAssignAttribute(bool assignable)
        {
            Assignable = assignable;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if item can be assigned by the user.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region IsGameModeAttibute
    /// <summary>
    /// Game mode attribute.
    /// Used to indicate wether the application mode is game. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IsGameModeAttibute : Attribute
    { }
    #endregion

    #region GUIDAttribue
    /// <summary>
    /// GUID Attribute.
    /// </summary>
    public class GUIDAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid.</param>
        /// <exception cref="ArgumentNullException"> thrown if <paramref name="guid"/> is equal to null or empty string.</exception>
        public GUIDAttribute(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentNullException(nameof(guid));

            Guid = new Guid(guid);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid instance.</param>
        public GUIDAttribute(Guid guid)
        {
            Guid = guid;
        }

        #endregion

        #region FIELDS
        private Guid guid;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets the GUID for this attribute.
        /// </summary>
        public Guid Guid
        {
            get { return guid; }
            protected set { guid = value; }
        }
        #endregion
    }
    #endregion

    #region SpecialFolderAttribute
    /// <summary>
    /// Special folder attribute.
    /// </summary>
    public class SpecialFolderAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SpecialFolderAttribute()
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="specialFolderType">Special folder type.</param>
        public SpecialFolderAttribute(Environment.SpecialFolder specialFolderType)
        {
            SpecialFolder = specialFolderType;
        }

        #endregion

        #region FIELDS
        private Environment.SpecialFolder folderType = (Environment.SpecialFolder)65535;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the folder type for this attribute.
        /// </summary>
        public Environment.SpecialFolder SpecialFolder
        {
            get { return folderType; }
            protected set { folderType = value; }
        }

        #endregion
    }
    #endregion

    #region AgeAttribute
    /// <summary>
    /// Age attribute.
    /// </summary>
    public class AgeRatingAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new age attribute.
        /// </summary>
        /// <param name="value">Age value.</param>
        public AgeRatingAttribute(uint value)
        {
            Age = value;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets attributes age value.
        /// </summary>
        public uint Age
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region PropertyMapAttribute
    /// <summary>
    /// Property map attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class PropertyMapAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public PropertyMapAttribute(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            typeId = Guid.NewGuid();

            PropertyName = propertyName;
        }

        #endregion

        #region FILEDS
        private Guid typeId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Property name.
        /// </summary>
        public string PropertyName
        {
            get; protected set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets type id.
        /// </summary>
        public override object TypeId
        {
            get
            {
                return typeId;
            }
        }

        #endregion
    }
    #endregion

    #region FilterPropertyAttribute
    /// <summary>
    /// Maps a class property to filter property name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class FilterPropertyAttribute : PropertyMapAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        public FilterPropertyAttribute(string propertyName, Op operation) : this(propertyName, operation, null, false)
        { }

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        /// <param name="groupName">Filter group name.</param>
        /// <param name="includedOnNull">Indicates if filter should be included on null values.</param>
        public FilterPropertyAttribute(string propertyName, Op operation, string groupName, bool includedOnNull) : this(propertyName, operation, groupName, includedOnNull, false)
        {
        }

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        /// <param name="groupName">Filter group name.</param>
        /// <param name="includedOnNull">Indicates if filter should be included on null values.</param>
        /// <param name="ignore">Indicates if property should be ignored when calling get filters function.</param>
        public FilterPropertyAttribute(string propertyName, Op operation, string groupName, bool includedOnNull, bool ignore) : base(propertyName)
        {
            Operation = operation;
            GroupName = groupName;
            IncludeOnNullValue = includedOnNull;
            Ignore = ignore;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if filter should be included if filter value equals to null.
        /// </summary>
        public bool IncludeOnNullValue
        {
            get; protected set;
        }

        /// <summary>
        /// Gets filtering operation.
        /// </summary>
        public Op Operation
        {
            get; protected set;
        }

        /// <summary>
        /// Filter group name.
        /// </summary>
        public string GroupName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if property should be ignored when calling get filters function.
        /// </summary>
        public bool Ignore
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
