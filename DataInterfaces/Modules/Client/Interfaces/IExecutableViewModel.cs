using SharedLib.Applications;
using SkinInterfaces.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public interface IExecutableViewModel
    {
        /// <summary>
        /// Gets attached executable.
        /// </summary>
        IExecutable Executable
        {
            get;
        }

        /// <summary>
        /// Gets laucnh command.
        /// </summary>
        IExecutionChangedAwareCommand LaunchCommand
        {
            get;
        }

        /// <summary>
        /// Gets terminate command.
        /// </summary>
        IExecutionChangedAwareCommand TerminateCommand
        {
            get;
        }

        /// <summary>
        /// Gets repair command.
        /// </summary>
        IExecutionChangedAwareCommand RepairCommand
        {
            get;
        }

        /// <summary>
        /// Gets navigate command.
        /// </summary>
        IExecutionChangedAwareCommand NavigateCommand
        {
            get;
        }
    }
}
