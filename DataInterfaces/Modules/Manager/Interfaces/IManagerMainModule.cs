using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Modules
{
    #region IManagerMainModule
    /// <summary>
    /// Manager main module interface.
    /// </summary>
    public interface IManagerMainModule : IPluginModule
    {
        /// <summary>
        /// Gets current manager plugable module.
        /// </summary>
        IManagerPlugableModule CurrentModule { get; }  

        /// <summary>
        /// Gets current manager side module.
        /// </summary>
        IManagerSideModule CurrentSideModule { get; }
    } 
    #endregion    
}
