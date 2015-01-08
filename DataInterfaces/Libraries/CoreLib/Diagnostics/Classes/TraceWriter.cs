using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CoreLib.Diagnostics
{
    #region TraceWriter
    public static class TraceWriter
    {
        #region Fields
        private static bool enabled = true;
        #endregion

        #region Functions

        public static void WriteLine(string message, Exception ex)
        {
            if (TraceWriter.TraceEnabled && message != null)
            {
                TraceWriter.WriteLine(String.Format("{0}\n{1}", message, ex));
            }
        }

        public static void WriteLine(object message, string category = null)
        {
            if (TraceWriter.TraceEnabled && message!=null)
            {
                string formatedMessage = String.Format("{1}\n{0}\n{2}", message, DateTime.Now, category);
                Trace.WriteLine(formatedMessage);
            }
                
        }

        /// <summary>
        /// Writes an exception to the crash log.
        /// </summary>
        /// <param name="ex">Crash exception.</param>
        public static void CrashLog(Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException();

            string executablePath = Process.GetCurrentProcess().MainModule.FileName;
            string executableName = Path.GetFileName(executablePath);
            string exeDirectory = Path.GetDirectoryName(executablePath);
            string logPath = Path.Combine(exeDirectory, String.Format("{0}-{1}", executableName, "crashlog.txt"));

            //write entry
            using (StreamWriter writer = new StreamWriter(logPath, true))
                writer.WriteLine("{0} [{1}]\r\n{2}", DateTime.Now, ex.Message, ex.ToString());           
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets if trace output is enabled.
        /// </summary>
        public static bool TraceEnabled
        {
            get { return TraceWriter.enabled; }
            set { TraceWriter.enabled = value; }
        }

        #endregion
    }
    #endregion
}
