using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Server license info class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class LicenseInfo : ILicense
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="parameters"></param>
        public LicenseInfo(Dictionary<string, object> parameters)
        {
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
        #endregion

        #region FIELDS
        private Dictionary<string, object> parameters;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets total amount of licenses.
        /// </summary>
        [DataMember()]
        public int TotalCount
        {
            get
            {
                return (HasValidTrialLicenses ? TrialCount : 0) + (HasValidLicenses ? Count : 0);
            }
        }

        /// <summary>
        /// Gets the amount of licenses.
        /// </summary>
        [DataMember()]
        public int Count
        {
            get { return (int)Parameters["count"]; }
        }

        /// <summary>
        /// Gets the amount of trial licenses.
        /// </summary>
        [DataMember()]
        public int TrialCount
        {
            get { return (int)Parameters["trialcount"]; }
        }

        /// <summary>
        /// Gets the hardware id that is assigned for this license.
        /// </summary>
        [DataMember()]
        public string HardwareId
        {
            get { return (string)Parameters["hardwareid"]; }
        }

        /// <summary>
        /// Gets if the license was loaded from local storage.
        /// </summary>
        [DataMember()]
        public bool Local
        {
            get
            {
                return (bool)Parameters["local"];
            }
        }

        /// <summary>
        /// Date the license was issued.
        /// </summary>
        [DataMember()]
        public DateTime Issued
        {
            get
            {
                return (DateTime)Parameters["issued"];
            }
        }

        /// <summary>
        /// Expiration date.
        /// </summary>
        [DataMember()]
        public DateTime Expires
        {
            get { return (DateTime)Parameters["expiredate"]; }
        }

        /// <summary>
        /// Trial expiration date.
        /// </summary>
        [DataMember()]
        public DateTime TrialExpires
        {
            get { return (DateTime)Parameters["trialexpiredate"]; }
        }

        /// <summary>
        /// Gets if trial license is server side expired.
        /// </summary>
        [DataMember()]
        public bool IsServerTrialExpired
        {
            get { return (bool)Parameters["servertrialexpired"]; }
        }

        /// <summary>
        /// Gets if license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalExpired
        {
            get { return Expires <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if trial license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalTrialExpired
        {
            get { return TrialExpires <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if license is server side expired.
        /// </summary>
        [DataMember()]
        public bool IsServerExpired
        {
            get { return (bool)Parameters["serverexpired"]; }
        }

        /// <summary>
        /// Gets if valid trial licenses present.
        /// </summary>
        [DataMember()]
        public bool HasValidTrialLicenses
        {
            get
            {
                return TrialCount >= 0 & !IsServerTrialExpired & !IsLocalTrialExpired;
            }
        }

        /// <summary>
        /// Gets if valid licenses present.
        /// </summary>
        [DataMember()]
        public bool HasValidLicenses
        {
            get
            {
                return Count >= 0 & !IsServerExpired & !IsLocalExpired;
            }
        }

        #region PRIVATE

        /// <summary>
        /// Gets or sets parameters.
        /// </summary>
        protected Dictionary<string, object> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        #endregion

        #endregion
    }
}
