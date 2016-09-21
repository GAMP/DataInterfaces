using Manager.Services;
using ServerService;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Manager
{
    #region AuthEventArgs
    public class AuthEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public AuthEventArgs(IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("IIdentity");

            this.Identity = identity;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets the event user identity.
        /// </summary>
        public IIdentity Identity
        {
            get;
            private set;
        }
        #endregion
    }
    #endregion

    #region CurrentServiceChangedEventArgs
    public class CurrentServiceChangedEventArgs : SelectedChangeEventArgs<IRemoteGizmoService>
    {
        #region CONSTRUCTOR
        public CurrentServiceChangedEventArgs(IRemoteGizmoService current, IRemoteGizmoService previous)
        {
            this.Current = current;
            this.Previous = previous;
        }
        #endregion
    }
    #endregion

    #region RFIDEventArgs
    public abstract class RFIDEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public RFIDEventArgs(string readerName)
        {
            if (string.IsNullOrWhiteSpace(readerName))
                throw new ArgumentNullException(nameof(readerName));

            this.ReaderName = readerName;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets associated reader name.
        /// </summary>
        public string ReaderName
        {
            get;
            private set;
        }
        #endregion
    } 
    #endregion

    #region RFIDScanEventArgs
    /// <summary>
    /// Rfid scanner service event args.
    /// </summary>
    public class RFIDScanEventArgs : RFIDEventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="readerName">Associated reader name.</param>
        /// <param name="uid">SmartCard UID.</param>
        public RFIDScanEventArgs(string readerName, byte[] uid):base(readerName)
        {
            //uid array must be set
            if (uid == null)
                throw new ArgumentNullException(nameof(uid));

            //check for valid uid length
            if (uid.Length < 4 || uid.Length > 7)
                throw new ArgumentNullException(nameof(uid));

            this.UID = uid;
        }

        /// <summary>
        /// Gets or sets SmartCard UID String.
        /// </summary>
        public string UIDString
        {
            get { return BitConverter.ToString(this.UID); }
        }

        /// <summary>
        /// Gets SmartCard UID.
        /// </summary>
        public byte[] UID
        {
            get; protected set;
        }
    } 
    #endregion
}
