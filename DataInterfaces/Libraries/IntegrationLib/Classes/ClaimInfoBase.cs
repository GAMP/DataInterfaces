using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    /// <summary>
    /// Claim info base class.
    /// Used to describe existing claims.
    /// </summary>
    public class ClaimInfoBase : IClaimInfo
    {
        public ClaimInfoBase(string type,string resource, string friendlyName,string description)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            this.Operation = type;
            this.Resource = resource;
            this.FriendlyName = friendlyName;
            this.Description = description;
        }

        public virtual string FriendlyName
        {
            get; protected set;
        }

        public virtual string Description
        {
            get; protected set;
        }
        
        public virtual string Resource
        {
            get; protected set;
        }

        public virtual string Operation
        {
            get; protected set;
        }

    }
}
