using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace IntegrationLib
{ 
    #region IProvidePrincipal
    public interface IProvidePrincipal
    {
        IPrincipal CreatePrincipal(HttpCredentials cr);
    }
    #endregion
}
