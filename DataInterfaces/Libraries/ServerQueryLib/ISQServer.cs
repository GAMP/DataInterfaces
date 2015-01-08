using System;

namespace ServerQueryLib
{
    [Obsolete()]
    public interface ISQServer
    {
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
    }
}
