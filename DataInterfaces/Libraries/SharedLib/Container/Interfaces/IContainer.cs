using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Container
{
    #region IContainer
    /// <summary>
    /// Container interface.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Gets or sets the container id.
        /// </summary>
        int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Restructs the container.
        /// </summary>
        void Restruct();

        /// <summary>
        /// Occours when items are changed witthin the container.
        /// </summary>
        event ContainerItemsEventDelegate ItemsEvent;
    }
    #endregion
}
