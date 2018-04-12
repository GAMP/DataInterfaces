using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CoreLib.Diagnostics
{
    #region TraceWriter
    public static class TraceWriter
    {
        #region FIELDS
        private static bool enabled = true;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets if trace output is enabled.
        /// </summary>
        public static bool TraceEnabled
        {
            get { return TraceWriter.enabled; }
            set { TraceWriter.enabled = value; }
        }

        #endregion

        #region FUNCTIONS

        public static void WriteLine(string message, Exception ex)
        {
            if (TraceWriter.TraceEnabled && message != null)
                TraceWriter.WriteLine(String.Format("{0}\n{1}", message, ex));           
        }

        public static void WriteLine(object message, string category = null)
        {
            if (TraceWriter.TraceEnabled && message != null)
            {
                string formatedMessage = String.Format("{1}\n{0}\n{2}", message, DateTime.Now, category);
                Trace.WriteLine(formatedMessage);
            }
        }
        
        public static void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (TraceWriter.TraceEnabled)
            {
                Trace.WriteLine("MESSAGE: " + message);
                Trace.WriteLine("MEMBER NAME: " + memberName);
                Trace.WriteLine("SOURCE FILE PATH: " + sourceFilePath);
                Trace.WriteLine("SOURCE LINE NUMBER: " + sourceLineNumber);
            }
        }

        public static void TraceException(Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (TraceWriter.TraceEnabled)
            {
                Trace.WriteLine("EXCEPTION: " + ex.ToString());
                Trace.WriteLine("MEMBER NAME: " + memberName);
                Trace.WriteLine("SOURCE FILE PATH: " + sourceFilePath);
                Trace.WriteLine("SOURCE LINE NUMBER: " + sourceLineNumber);
            }
        }

        #endregion        
    }
    #endregion
}
