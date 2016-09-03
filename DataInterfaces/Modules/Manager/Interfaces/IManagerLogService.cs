using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Manager log message service.
    /// </summary>
    public interface IManagerLogService
    {
        #region EVENTS

        /// <summary>
        /// Occurs once a new message added to manager message log.
        /// </summary>
        event EventHandler<MessageLogEventArgs> MessageEvent;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Add information message.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="message"/> equals to null or empty string.
        /// </exception>
        void AddInformation(string message);

        /// <summary>
        /// Add warning message.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="message"/> equals to null or empty string.
        /// </exception>
        void AddWarning(string message);

        /// <summary>
        /// Add error message.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="message"/> equals to null or empty string.
        /// </exception>
        void AddError(string message);

        /// <summary>
        /// Add error message.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="ex">Exception instance.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="message"/> equals to null or empty string.
        /// </exception>
        void AddError(string message, Exception ex=null);


        /// <summary>
        /// Add message.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="endpointName">Endpoint name string.</param>
        /// <param name="type">Message type.</param>
        /// <param name="error">Exception.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="message"/> equals to null or empty string.
        /// </exception>
        void AddMessage(string message, string endpointName, EventTypes type, Exception error=null);

        #endregion
    }
}
