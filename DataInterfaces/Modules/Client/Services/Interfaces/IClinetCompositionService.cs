using System.Collections.Generic;
using System.Reflection;

namespace Client
{
    /// <summary>
    /// Client compisition service.
    /// </summary>
    public interface IClinetCompositionService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets exported value of <typeparamref name="T"/>.
        /// </summary>
        T GetExportedValue<T>();

        /// <summary>
        /// Gets exported values of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of export.</typeparam>
        /// <returns>List of export of type specified by <typeparamref name="T"/></returns>
        IEnumerable<T> GetExportedValues<T>();

        /// <summary>
        /// Adds an assembly to composition container.
        /// </summary>
        /// <param name="assembly">Assembly.</param>
        void AddAssembly(Assembly assembly); 

        #endregion
    }
}