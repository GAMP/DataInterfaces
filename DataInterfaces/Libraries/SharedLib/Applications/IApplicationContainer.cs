using System.Collections.Generic;

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

        /// <summary>
        /// Gets container categories.
        /// </summary>
        IEnumerable<ICategory> Categories { get; }

        /// <summary>
        /// Gets container applications.
        /// </summary>
        IEnumerable<IApplicationProfile> Applications { get; }

        /// <summary>
        /// Gets application by id.
        /// </summary>
        /// <param name="id">Application id.</param>
        /// <returns>Application profile, null case no profile found.</returns>
        IApplicationProfile FindApplication(int id);

        /// <summary>
        /// Gets category by id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>Category, null case no category found.</returns>
        ICategory FindCategory(int id);
    }
}
