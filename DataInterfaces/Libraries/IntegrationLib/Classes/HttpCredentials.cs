using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region HttpCredentials
    public class HttpCredentials
    {
        #region Properties
        /// <summary>
        /// Gets credentials username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets credentials password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets if credentials are empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return String.IsNullOrWhiteSpace(this.Username) & String.IsNullOrWhiteSpace(this.Password); }
        }
        #endregion
    }
    #endregion
}
