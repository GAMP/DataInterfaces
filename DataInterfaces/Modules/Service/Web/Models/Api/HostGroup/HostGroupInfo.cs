using SharedLib;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Host group info.
    /// </summary>
    [DataContract()]
    public class HostGroupInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Host group id.
        /// </summary>
        [DataMember()]
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Host group name.
        /// </summary>
        [DataMember()]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Skin name.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue =false)]
        public string SkinName
        {
            get; set;
        }

        /// <summary>
        /// Options.
        /// </summary>
        [DataMember()]
        public HostGroupOptionType Options
        {
            get;
            set;
        }

        /// <summary>
        /// App group id.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false)]
        public int? AppGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Security profile id.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false)]
        public int? SecurityProfileId
        {
            get;
            set;
        }

        /// <summary>
        /// Default guest group id.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false)]
        public int? DefaultGuestGroupId
        {
            get; set;
        } 

        #endregion
    }
}
