using SharedLib;
using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// License reservation class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class LicenseReservation : ItemObject, ILicenseReservation
    {
        #region CONSTRUCTOR

        public LicenseReservation()
        { }

        public LicenseReservation(int id, Dictionary<int, IApplicationLicense> licenses, IMessageDispatcher dispatcher)
        {
            this.Id = id;
            this.Licenses = licenses;
            this.Dispatcher = dispatcher;
            this.HostId = hostId;
        }

        #endregion

        #region FIELDS
        private Dictionary<int, IApplicationLicense> licenses;
        [NonSerialized()]
        private IMessageDispatcher dispatcher;
        [OptionalField(VersionAdded = 2)]
        private int hostId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the list of reserved licenses.
        /// </summary>
        [IgnoreDataMember()]
        public Dictionary<int, IApplicationLicense> Licenses
        {
            get
            {
                if (this.licenses == null)
                    this.licenses = new Dictionary<int, IApplicationLicense>();
                return this.licenses;
            }
            protected set { this.licenses = value; }
        }

        /// <summary>
        /// Gets the message dispatcher.
        /// </summary>
        [IgnoreDataMember()]
        public IMessageDispatcher Dispatcher
        {
            get { return this.dispatcher; }
            protected set { this.dispatcher = value; }
        }

        /// <summary>
        /// Gets application name.
        /// </summary>
        [DataMember(Order = 0)]
        public string Application
        {
            get;
            set;
        }

        /// <summary>
        /// Gets executable name.
        /// </summary>
        [DataMember(Order = 1)]
        public string Executable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        [DataMember(Order = 3)]
        public int HostId
        {
            get { return this.hostId; }
            set { this.hostId = value; }
        }

        /// <summary>
        /// Gets license keys.
        /// </summary>
        [DataMember(Order = 3)]
        public IEnumerable<IApplicationLicense> LicenseKeys
        {
            get { return this.Licenses.Values; }
        }

        #endregion
    }
}
