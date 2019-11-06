using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Generic trace writer.
    /// </summary>
    public static class TraceWriter
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if trace output is enabled.
        /// </summary>
        public static bool TraceEnabled
        {
            get;set;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Writes trace line.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        public static void WriteLine(string message, Exception ex)
        {
            if (TraceEnabled && message != null)
                WriteLine(string.Format("{0}\n{1}", message, ex));           
        }

        /// <summary>
        /// Writes trace line.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        public static void WriteLine(object message, string category = null)
        {
            if (TraceEnabled && message != null)
            {
                string formatedMessage = string.Format("{1}\n{0}\n{2}", message, DateTime.Now, category);
                Trace.WriteLine(formatedMessage);
            }
        }
        
        /// <summary>
        /// Traces a message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="memberName">Memeber name.</param>
        /// <param name="sourceFilePath">Source file path.</param>
        /// <param name="sourceLineNumber">Source line number.</param>
        public static void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (TraceEnabled)
            {
                Trace.WriteLine("MESSAGE: " + message);
                Trace.WriteLine("MEMBER NAME: " + memberName);
                Trace.WriteLine("SOURCE FILE PATH: " + sourceFilePath);
                Trace.WriteLine("SOURCE LINE NUMBER: " + sourceLineNumber);
            }
        }

        /// <summary>
        /// Traces an exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        /// <param name="memberName">Memeber name.</param>
        /// <param name="sourceFilePath">Source file path.</param>
        /// <param name="sourceLineNumber">Source line number.</param>
        public static void TraceException(Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (TraceEnabled)
            {
                Trace.WriteLine("EXCEPTION: " + ex.ToString());
                Trace.WriteLine("MEMBER NAME: " + memberName);
                Trace.WriteLine("SOURCE FILE PATH: " + sourceFilePath);
                Trace.WriteLine("SOURCE LINE NUMBER: " + sourceLineNumber);
            }
        }

        #endregion        
    }
}
