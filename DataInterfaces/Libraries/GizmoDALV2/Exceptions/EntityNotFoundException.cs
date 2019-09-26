using System;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    #region ENTITYNOTFOUNDEXCPETION
    [DataContract()]
    [Serializable()]
    public class EntityNotFoundException : Exception
    {
        #region CONSTRUCTOR

        public EntityNotFoundException() : base() { }

        public EntityNotFoundException(int entityKey, Type entityType) : this()
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            EntityKey = entityKey;
            EntityType = entityType;
        }

        public EntityNotFoundException(object[] keys, Type entityType) : this()
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            Keys = keys;
            EntityType = entityType;
        }

        public EntityNotFoundException(string message)
            : base(message)
        { }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

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
    #endregion
}
