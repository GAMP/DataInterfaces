using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerService;

namespace IntegrationLib
{
    public interface IServicePlugin : IPlugin
    {
        void OnInitialize(); 
    }
}
