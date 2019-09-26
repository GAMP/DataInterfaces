using SharedLib.Dispatcher;
using System;
using System.IO;

namespace CyClone.Security
{
    public class VerifyAccessEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public VerifyAccessEventArgs(string path,
            IMessageDispatcher dispatcher,
            FileAccess access,
            FileMode mode,
            bool sucess = true)
        {
            TimeStamp = DateTime.Now;
            Access = access;
            Mode = mode;
            Path = path;
            Dispatcher = dispatcher;
            Sucess = sucess;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets verification access flags.
        /// </summary>
        public FileAccess Access
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the calling dispatcher.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the path verified.
        /// </summary>
        public string Path
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets if verification was sucessfull.
        /// </summary>
        public bool Sucess
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets verification file mode flag.
        /// </summary>
        public FileMode Mode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets event time stamp.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            protected set;
        }

        #endregion
    }
}
