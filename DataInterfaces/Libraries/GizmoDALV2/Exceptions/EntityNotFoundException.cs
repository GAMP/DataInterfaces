using System;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    /// <summary>
    /// Entity not found exception.
    /// </summary>
    /// <remarks>
    /// Thrown when trying to query database entity by id for non existing record.
    /// </remarks>
    [DataContract()]
    [Serializable()]
    public class EntityNotFoundException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public EntityNotFoundException() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="entityKey">Entity key.</param>
        /// <param name="entityType">Entity type.</param>
        public EntityNotFoundException(int entityKey, Type entityType) : this()
        {
            EntityKey = entityKey;
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="keys">Entity keys.</param>
        /// <param name="entityType">Entity type.</param>
        public EntityNotFoundException(object[] keys, Type entityType) : this()
        {
            Keys = keys ?? throw new ArgumentNullException(nameof(keys));
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public EntityNotFoundException(string message)
            : base(message)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected EntityNotFoundException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                EntityType = (Type)info.GetValue(nameof(EntityType), typeof(Type));
                EntityKey = (int?)info.GetValue(nameof(EntityKey), typeof(int?));
                Keys = (object[])info.GetValue(nameof(Keys), typeof(object[]));
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
                info.AddValue(nameof(EntityKey), EntityKey);
                info.AddValue(nameof(Keys), Keys);
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets entity id.
        /// </summary>
        [DataMember()]
        public int? EntityKey
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
        /// Gets entity keys.
        /// </summary>
        public object[] Keys
        {
            get; set;
        }

        #endregion
    }
}
