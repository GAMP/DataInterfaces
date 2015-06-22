using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Dispatcher
{
    #region DISPATCHEREXTENSIONS
    public static class DispatcherExtensions
    {
        /// <summary>
        /// Throws argument exception if specified dispatcher is null.
        /// </summary>
        /// <param name="dispatcher">Dispathcer instance.</param>
        public static void ThrowDispatcherNull(this IMessageDispatcher dispatcher)
        {
            if (dispatcher == null)
                throw new ArgumentNullException(nameof(dispatcher), "Dispatcher instance may not be null");
        }

        /// <summary>
        /// Throws exception if current dispatcher is invalid.
        /// </summary>
        /// <param name="dispathcer">Dispathcer instance.</param>
        public static void ThrowIfInvalidDispatcher(this IMessageDispatcher dispatcher)
        {
            dispatcher.ThrowDispatcherNull();

            if (!dispatcher.IsValid)
                throw new ArgumentException("No connections is present. Command dispatcher is in invalid state.");
        }

    }
    #endregion
}
