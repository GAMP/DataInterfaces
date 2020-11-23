using CoreLib;

namespace SharedLib
{
    /// <summary>
    /// Restriction implementation interface.
    /// </summary>
    public interface IRestriction
    {
        #region PROPERTIES
        /// <summary>
        /// Id.
        /// </summary>
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
        #endregion
    } 
}
