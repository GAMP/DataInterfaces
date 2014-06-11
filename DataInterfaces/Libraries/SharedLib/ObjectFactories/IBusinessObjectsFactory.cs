using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Management;
using SharedLib.Applications;
using IntegrationLib;
using SharedLib.User;
using NetLib;

namespace SharedLib.Data
{
    /// <summary>
    /// Business object factory interface.
    /// </summary>
    public interface IBusinessObjectsFactory
    {    
        IHostEntry CreateHostBase();

        IApplicationLicense CreateApplicationLicense();

        IUserProfile CreateUserProfile();

        IApplicationProfile CreateApplicationProfile();

        IVariable CreateVariable();
    }
}
