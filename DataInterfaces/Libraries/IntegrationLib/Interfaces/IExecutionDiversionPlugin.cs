using Client;

namespace IntegrationLib
{
    /// <summary>
    /// Execution divertion plugin implementation interface.
    /// </summary>
    public interface IExecutionDivertPlugin
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Diverts process creation to plugin.
        /// </summary>
        /// <param name="context">Execution context.</param>
        /// <returns>True if execution diverted , false otherwise.</returns>
        bool DivertExecution(IExecutionContext context); 

        #endregion
    }
}
