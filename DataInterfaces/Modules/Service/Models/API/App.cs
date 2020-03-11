using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// App entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class App : ModifiableByUserBase
    {
        #region App

        /// <summary>
        /// Gets or Sets application title.
        /// </summary>
        [Required()]
        [ProtoMember(1)]
        [DataMember()]
        [StringLength(255)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets application description.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets application version.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        [StringLength(45)]
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets applications genre.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int AppCategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets applications developer.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int? DeveloperId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets applications publisher.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int? PublisherId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets applications age rating.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int AgeRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets applications release date.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? ReleaseDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets application halt on error value.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public AppOptionType Options
        {
            get;
            set;
        }

        /// <summary>
        /// Gets age rating type.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public AgeRatingType AgeRatingType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets items guid.
        /// <remarks>This property is required to globaly identify the object. In case of exporting or importing applications it gives us ability to have unique objects.</remarks>
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        [Required()]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets default executable id.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public int? DefaultExecutableId
        {
            get; set;
        }

        #endregion

    }
}
