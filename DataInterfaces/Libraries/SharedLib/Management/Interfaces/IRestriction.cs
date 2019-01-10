using System;
using CoreLib;

namespace SharedLib
{
    #region IRestriction
    public interface IRestriction
    {
        int Id { get; set; }

        /// <summary>
        /// Gets restriction parameter.
        /// </summary>
        string Parameter { get; }

        /// <summary>
        /// Gets restriction type.
        /// </summary>
        RestrictionType Type { get; set; }

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        int ProfileId { get; set; }
    } 
    #endregion

    #region Restriction
    /// <summary>
    /// Base restriction class.
    /// </summary>
    [Serializable()]
    public class Restriction : ItemObject, IRestriction
    {
        #region Constructor

        public Restriction()
        { 
        }

        public Restriction(int profileId)
        {
            this.ProfileId = ProfileId;
        }

        public Restriction(RestrictionType type, string parameter):this()
        {
            if (!String.IsNullOrWhiteSpace(parameter))
            {
                this.Parameter = parameter;
                this.Type = type;
            }
            else
            {
                throw new NullReferenceException("Restriction parameter cannot be null or empty.");
            }
        }
        
        #endregion

        #region Fields
        private string parameter;
        private RestrictionType type;
        private int profileId;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        public int ProfileId
        {
            get { return this.profileId; }
            set
            {
                this.profileId = value;
                this.RaisePropertyChanged("ProfileId");
            }
        }

        /// <summary>
        /// Gets restriction parameter.
        /// </summary>
        public string Parameter
        {
            get { return this.parameter; }
            set
            {
                this.parameter = value;
                this.RaisePropertyChanged("Parameter");
            }
        }

        /// <summary>
        /// Gets restriction type.
        /// </summary>
        public RestrictionType Type
        {
            get { return this.type; }
            set
            {
                this.type = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        #endregion
    } 
    #endregion
}
