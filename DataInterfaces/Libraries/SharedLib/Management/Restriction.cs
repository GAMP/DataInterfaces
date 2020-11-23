using CoreLib;
using System;

namespace SharedLib
{
    /// <summary>
    /// Base restriction class.
    /// </summary>
    [Serializable()]
    public class Restriction : ItemObject, IRestriction
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public Restriction()
        {
        }

        #endregion

        #region FIELDS
        private string parameter;
        private RestrictionType type;
        private int profileId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        public int ProfileId
        {
            get { return profileId; }
            set
            {
                profileId = value;
                RaisePropertyChanged("ProfileId");
            }
        }

        /// <summary>
        /// Gets restriction parameter.
        /// </summary>
        public string Parameter
        {
            get { return parameter; }
            set
            {
                parameter = value;
                RaisePropertyChanged("Parameter");
            }
        }

        /// <summary>
        /// Gets restriction type.
        /// </summary>
        public RestrictionType Type
        {
            get { return type; }
            set
            {
                type = value;
                RaisePropertyChanged("Type");
            }
        }

        #endregion
    }
}
