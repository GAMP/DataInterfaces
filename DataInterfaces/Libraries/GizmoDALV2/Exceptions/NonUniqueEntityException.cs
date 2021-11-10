using System;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    /// <summary>
    /// Non unique entity value exception.
    /// Thrown when trying to update or create an entity and another entity has same unique value.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class NonUniqueEntityValueException : Exception
    {
        #region CONSTRUCTOR

        public NonUniqueEntityValueException():base()
        {
        }

        public NonUniqueEntityValueException(string message):base(message)
        {
        }

        public NonUniqueEntityValueException(string message, Exception inner)
           : base(message, inner)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Entity key.</param>
        /// <param name="value">Value.</param>
        /// <param name="entityType">Entity type.</param>
        public NonUniqueEntityValueException(string propertyName, object value, Type entityType) : base()
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(PropertyName));

            PropertyName = propertyName;
            Value = value;
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected NonUniqueEntityValueException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                EntityType = (Type)info.GetValue(nameof(EntityType), typeof(Type));
                PropertyName = (string)info.GetValue(nameof(PropertyName), typeof(string));
                Value = info.GetValue(nameof(Value), typeof(object));
            }
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets object data.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(EntityType), EntityType);
                info.AddValue(nameof(PropertyName), PropertyName);
                info.AddValue(nameof(Value), Value);
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets entity property name.
        /// </summary>
        [DataMember()]
        public string PropertyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        [DataMember()]
        public Type EntityType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity value.
        /// </summary>
        public object Value
        {
            get; set;
        }

        #endregion
    }
}
