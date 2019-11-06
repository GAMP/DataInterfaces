using System;

namespace ServerQueryLib
{
    /// <summary>
    /// Server query interface.
    /// </summary>
    [Obsolete()]
    public interface ISQServer
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets server name.
        /// </summary>
        string GameServerName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets if querying is currently enabled.
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets server id.
        /// </summary>
        int ID { get; set; } 

        #endregion
    }
}
