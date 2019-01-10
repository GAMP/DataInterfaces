using Manager.Services;
using SharedLib;
using System;
using System.Security.Principal;

namespace Manager
{
    #region AUTHEVENTARGS
    public class AuthEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public AuthEventArgs(IIdentity identity)
        {
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
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

    #region CURRENTSERVICECHANGEDEVENTARGS
    public class CurrentServiceChangedEventArgs : SelectedChangeEventArgs<IRemoteGizmoService>
    {
        #region CONSTRUCTOR
        public CurrentServiceChangedEventArgs(IRemoteGizmoService current, IRemoteGizmoService previous)
        {
            Current = current;
            Previous = previous;
        }
        #endregion
    }
    #endregion

    #region RFIDEVENTARGS
    public abstract class RFIDEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public RFIDEventArgs(string readerName)
        {
            if (string.IsNullOrWhiteSpace(readerName))
                throw new ArgumentNullException(nameof(readerName));

            ReaderName = readerName;
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

    #region RFIDSCANEVENTARGS
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
        public RFIDScanEventArgs(string readerName, byte[] uid) : base(readerName)
        {
            //uid array must be set
            if (uid == null)
                throw new ArgumentNullException(nameof(uid));

            //check for valid uid length
            if (uid.Length < 4 || uid.Length > 7)
                throw new ArgumentNullException(nameof(uid));

            UID = uid;
        }

        /// <summary>
        /// Gets SmartCard UID String.
        /// </summary>
        public string UIDString
        {
            get { return BitConverter.ToString(UID); }
        }

        /// <summary>
        /// Gets SmartCard UID.
        /// </summary>
        public byte[] UID
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets if event was handled.
        /// </summary>
        public bool IsHandled
        {
            get; set;
        }
    }
    #endregion

    #region PERMISSIONCHANGEEVENTARGS
    public class PermissionChangeEventArgs : EventArgs
    { }
    #endregion
}
