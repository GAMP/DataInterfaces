using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerService;
using IntegrationLib;

namespace ServerService
{
    public interface IServicePlugin : IPlugin
    {
        void OnInitialize(); 
    }
}
