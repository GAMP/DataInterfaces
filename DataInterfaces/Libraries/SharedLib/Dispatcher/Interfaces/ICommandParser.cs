using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region ICommandParser
    /// <summary>
    /// Base interface for an command parser.
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Tries to parse command.
        /// </summary>
        /// <param name="cmd">Command to parse.</param>
        /// <returns>True or false.</returns>
        bool TryParse(IDispatcherCommand cmd);
        
        /// <summary>
        /// Parses the command and throws exception in case of error.
        /// </summary>
        /// <param name="cmd"></param>
        void Parse(IExecutionCommand cmd);
       
        /// <summary>
        /// Tries to parse command.
        /// </summary>
        /// <param name="cmd">Command to parse.</param>
        /// <returns>True or false.</returns>
        bool TryParse(IExecutionCommand cmd);
    } 
    #endregion

    #region CommandParserBase
    /// <summary>
    /// Command parsing implementation base class.
    /// </summary>
    public abstract class CommandParserBase : ICommandParser
    {
        public virtual bool TryParse(IDispatcherCommand cmd)
        {
            throw new NotImplementedException();
        }

        public virtual void Parse(IExecutionCommand cmd)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryParse(IExecutionCommand cmd)
        {
            throw new NotImplementedException();
        }
    } 
    #endregion 
}
