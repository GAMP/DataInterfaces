using ServerService;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class LicenseInfo : ILicense
    {
        #region CONSTRUCTOR
        public LicenseInfo(Dictionary<string, object> parameters)
        {
            this.Parameters = parameters;
        } 
        #endregion

        #region FIELDS
        private Dictionary<string, object> parameters;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets total ammount of licenses.
        /// </summary>
        [DataMember()]
        public int TotalCount
        {
            get
            {
                return (this.HasValidTrialLicenses ? this.TrialCount : 0) + (this.HasValidLicenses ? this.Count : 0);
            }
        }

        /// <summary>
        /// Gets the ammount of licenses.
        /// </summary>
        [DataMember()]
        public int Count
        {
            get { return (int)this.Parameters["count"]; }
        }

        /// <summary>
        /// Gets the ammount of trial licenses.
        /// </summary>
        [DataMember()]
        public int TrialCount
        {
            get { return (int)this.Parameters["trialcount"]; }
        }

        /// <summary>
        /// Gets the hardware id that is assigned for this license.
        /// </summary>
        [DataMember()]
        public string HardwareId
        {
            get { return (string)this.Parameters["hardwareid"]; }
        }

        /// <summary>
        /// Gets if the license was loaded from local storage.
        /// </summary>
        [DataMember()]
        public bool Local
        {
            get
            {
                return (bool)this.Parameters["local"];
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
                return (DateTime)this.Parameters["issued"];
            }
        }

        /// <summary>
        /// Expiration date.
        /// </summary>
        [DataMember()]
        public DateTime Expires
        {
            get { return (DateTime)this.Parameters["expiredate"]; }
        }

        /// <summary>
        /// Trial expiration date.
        /// </summary>
        [DataMember()]
        public DateTime TrialExpires
        {
            get { return (DateTime)this.Parameters["trialexpiredate"]; }
        }

        /// <summary>
        /// Gets if trial license is server side expired.
        /// </summary>
        [DataMember()]
        public bool IsServerTrialExpired
        {
            get { return (bool)this.Parameters["servertrialexpired"]; }
        }

        /// <summary>
        /// Gets if license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalExpired
        {
            get { return this.Expires <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if trial license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalTrialExpired
        {
            get { return this.TrialExpires <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if license is server side expired.
        /// </summary>
        [DataMember()]
        public bool IsServerExpired
        {
            get { return (bool)this.Parameters["serverexpired"]; }
        }

        /// <summary>
        /// Gets if valid trial licenses present.
        /// </summary>
        [DataMember()]
        public bool HasValidTrialLicenses
        {
            get
            {
                return this.TrialCount >= 0 & !this.IsServerTrialExpired & !this.IsLocalTrialExpired;
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
                return this.Count >= 0 & !this.IsServerExpired & !this.IsLocalExpired;
            }
        }

        #region PRIVATE

        protected Dictionary<string, object> Parameters
        {
            get { return this.parameters; }
            set { this.parameters = value; }
        }

        #endregion

        #endregion
    }
}
