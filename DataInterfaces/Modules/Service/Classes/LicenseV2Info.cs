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
    public class LicenseV2Info : ILicenseV2
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="parameters"></param>
        public LicenseV2Info(Dictionary<string, object> parameters)
        {
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
        #endregion

        #region FIELDS
        private Dictionary<string, object> parameters;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Date the license was issued.
        /// </summary>
        [DataMember()]
        public DateTime IssueDate
        {
            get
            {
                return (DateTime)Parameters["issued"];
            }
        }

        /// <summary>
        /// Gets the hardware id that is assigned for this license.
        /// </summary>
        [DataMember()]
        public string HardwareId
        {
            get { return (string)Parameters["hardwareid"]; }
        }

        [DataMember()]
        public SubscriptionHardwareIdStatus HardwareIdStatus
        {
            get { return (SubscriptionHardwareIdStatus)Parameters["hardwareidstatus"]; }
        }

        /// <summary>
        /// Gets the amount of trial licenses.
        /// </summary>
        [DataMember()]
        public int TrialLicensesCount
        {
            get { return (int)Parameters["trialcount"]; }
        }

        /// <summary>
        /// Trial creation date.
        /// </summary>
        [DataMember()]
        public DateTime TrialCreationDate
        {
            get { return (DateTime)Parameters["trialcreationdate"]; }
        }

        /// <summary>
        /// Trial expiration date.
        /// </summary>
        [DataMember()]
        public DateTime TrialExpirationDate
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
        /// Gets total amount of licenses.
        /// </summary>
        [DataMember()]
        public int TotalLicensesCount
        {
            get { return (int)Parameters["totallicensescount"]; }
        }

        /// <summary>
        /// Gets the amount of licenses assigned to this hardware id.
        /// </summary>
        [DataMember()]
        public int LicensesAssigned
        {
            get { return (int)Parameters["count"]; }
        }

        /// <summary>
        /// Expiration date.
        /// </summary>
        [DataMember()]
        public DateTime ExpirationDate
        {
            get { return (DateTime)Parameters["expiredate"]; }
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
        /// Gets if subscription is recurring.
        /// </summary>
        [DataMember()]
        public bool IsRecurring
        {
            get
            {
                if (Parameters.ContainsKey("isrecurring"))
                    return (bool)Parameters["isrecurring"];
                else
                    return false;
            }
        }

        [DataMember()]
        public SubscriptionWarnings SubscriptionWarnings
        {
            get
            {
                if (Parameters.ContainsKey("subscriptionwarnings"))
                    return (SubscriptionWarnings)Parameters["subscriptionwarnings"];
                else
                    return SubscriptionWarnings.None;
            }
        }

        /// <summary>
        /// Gets if advanced mode.
        /// </summary>
        [DataMember()]
        public bool IsAdvancedMode
        {
            get { return (bool)Parameters["isadvancedmode"]; }
        }

        /// <summary>
        /// License expiration date.
        /// </summary>
        [DataMember()]
        public DateTime LicenseExpirationDate
        {
            get { return (DateTime)Parameters["licenseexpirationdate"]; }
        }

        /// <summary>
        /// Gets if user authorization failed.
        /// </summary>
        [DataMember()]
        public bool Unauthorized
        {
            get
            {
                if (Parameters.ContainsKey("unauthorized"))
                    return (bool)Parameters["unauthorized"];
                else
                    return false;
            }
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
        /// Gets if license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalExpired
        {
            get { return ExpirationDate <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if trial license is expired locally.
        /// </summary>
        [DataMember()]
        public bool IsLocalTrialExpired
        {
            get { return TrialExpirationDate <= InternalDate.Now; }
        }

        /// <summary>
        /// Gets if valid trial licenses present.
        /// </summary>
        [DataMember()]
        public bool HasValidTrialLicenses
        {
            get
            {
                return TrialLicensesCount >= 0 & !IsServerTrialExpired & !IsLocalTrialExpired;
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
                return LicensesAssigned >= 0 & !IsServerExpired & !IsLocalExpired;
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