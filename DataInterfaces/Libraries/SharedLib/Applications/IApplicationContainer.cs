using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SharedLib.Applications
{
    public interface IApplicationContainer
    {
        /// <summary>
        /// Checks if shared profile with specified name already exists.
        /// </summary>
        /// <typeparam name="T">Profile type.</typeparam>
        /// <param name="name">Profile Name.</param>
        /// <param name="ignoreId">Profile id to ignore.</param>
        /// <returns>True or false.</returns>
        bool NamedSharedProfileExists<T>(string name, int ignoreId);
    }
}
