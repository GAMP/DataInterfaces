using Manager.Services;
using SharedLib;
using System;
using System.Security.Principal;

namespace Manager
{
    #region AUTHEVENTARGS
    /// <summary>
    /// Auth event args.
    /// </summary>
    public class AuthEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="identity">User identity.</param>
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
    /// <summary>
    /// Current service changed event args.
    /// </summary>
    public class CurrentServiceChangedEventArgs : SelectedChangeEventArgs<IRemoteGizmoService>
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="current">Current service.</param>
        /// <param name="previous">Previous service.</param>
        public CurrentServiceChangedEventArgs(IRemoteGizmoService current, IRemoteGizmoService previous)
        {
            Current = current;
            Previous = previous;
        }
        #endregion
    }
    #endregion

    #region RFIDEVENTARGS
    /// <summary>
    /// Rfid event args.
    /// </summary>
    public abstract class RFIDEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="readerName">Reader name.</param>
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
    /// <summary>
    /// Permission change event args.
    /// </summary>
    public class PermissionChangeEventArgs : EventArgs
    { }
    #endregion
}
