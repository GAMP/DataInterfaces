using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.User
{
    #region IUserSession
    public interface IUserSession
    {
        /// <summary>
        /// Gets session creation time.
        /// </summary>
        DateTime CreationTime { get; }
        /// <summary>
        /// Gets if session is currently active.
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Gets session span.
        /// </summary>
        TimeSpan Span { get; }
        /// <summary>
        /// Gets total span from session creation.
        /// </summary>
        TimeSpan SpanFromCreation { get; }
        /// <summary>
        /// Gets sessions user id.
        /// </summary>
        int UserId { get; }
        /// <summary>
        /// Gets sessions host id.
        /// </summary>
        int HostId { get; }
        /// <summary>
        /// Gets session state.
        /// </summary>
        SessionState State { get; }
        /// <summary>
        /// Gets if session is currently pending.
        /// </summary>
        bool IsPending { get; }
        /// <summary>
        /// Gets if session is currently paused.
        /// </summary>
        bool IsPaused { get; }

    }
    #endregion
}
