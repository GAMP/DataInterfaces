using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User note entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserNote : ModifiableByUserBase
    {
        #region UserNote

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user note options.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public UserNoteOptions UserNoteOptions
        {
            get; set;
        }

        #endregion

        #region Note

        /// <summary>
        /// Gets or sets note text.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(65535)]
        [ProtoMember(3)]
        public string Text
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets note options.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public NoteOptions Options
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets note sevirirty.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public NoteSeverity Sevirity
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if note is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public bool IsDeleted
        {
            get; set;
        }

        #endregion
        
    }
}