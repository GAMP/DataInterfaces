using SharedLib;
using System;
using System.Collections.Generic;

namespace IntegrationLib
{
    public interface IAuthResult
    {
        /// <summary>
        /// Gets custom data dictionary.
        /// </summary>
        Dictionary<string, object> Custom { get; }

        /// <summary>
        /// Gets user identity.
        /// </summary>
        IUserIdentity Identity { get; set; }

        /// <summary>
        /// Gets required info.
        /// </summary>
        UserInfoTypes RequiredInfo { get; set; }

        /// <summary>
        /// Gets result.
        /// </summary>
        LoginResult Result { get; set; }
    }
}
