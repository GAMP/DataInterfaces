using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows;

namespace SkinInterfaces.Code
{
    #region SimpleCommand
    /// <summary>
    /// Implements the ICommand and wraps up all the verbose stuff so that you 
    /// can just pass 2 delegates 1 for the CanExecute and one for the Execute
    /// </summary>
    public class SimpleCommand : ICommand
    {
        #region Public Properties
        public Boolean CommandSucceeded { get; set; }
        /// <summary>
        /// Gets or sets the Predicate to execute when the 
        /// CanExecute of the command gets called
        /// </summary>
        public Predicate<object> CanExecuteDelegate { get; set; }
        /// <summary>
        /// Gets or sets the action to be called when the 
        /// Execute method of the command gets called
        /// </summary>
        public Action<object> ExecuteDelegate { get; set; }
        #endregion

        #region ICommand Members

        /// <summary>
        /// Checks if the command Execute method can run
        /// </summary>
        /// <param name="parameter">THe command parameter to be passed</param>
        /// <returns>Returns true if the command can execute. 
        /// By default true is returned so that if the user of SimpleCommand 
        /// does not specify a CanExecuteCommand delegate the command 
        /// still executes.</returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true;// if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the actual command
        /// </summary>
        /// <param name="parameter">THe command parameter to be passed</param>
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
                CommandSucceeded = true;
            }
        }

        #endregion
    }
    #endregion

    #region ICompletionAwareCommand
    /// <summary>
    /// Interface that is used for ICommands that notify when they are
    /// completed
    /// </summary>
    public interface ICompletionAwareCommand
    {
        /// <summary>
        /// Notifies that the command has completed
        /// </summary>
        //event Action<Object> CommandCompleted;

        WeakActionEvent<object> CommandCompleted { get; set; }
    }
    #endregion

    #region SimpleCommand
    /// <summary>
    /// Simple delegating command, based largely on DelegateCommand from PRISM/CAL
    /// </summary>
    /// <typeparam name="T">The type for the </typeparam>
    public class SimpleCommand<T1, T2> : ICommand, ICompletionAwareCommand
    {
        private Func<T1, bool> canExecuteMethod;
        private Action<T2> executeMethod;

        public SimpleCommand(Func<T1, bool> canExecuteMethod, Action<T2> executeMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
            this.CommandCompleted = new WeakActionEvent<object>();
        }

        public SimpleCommand(Action<T2> executeMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = (x) => { return true; };
            this.CommandCompleted = new WeakActionEvent<object>();
        }

        public WeakActionEvent<object> CommandCompleted { get; set; }

        public bool CanExecute(T1 parameter)
        {
            if (canExecuteMethod == null) return true;
            return canExecuteMethod(parameter);
        }

        public void Execute(T2 parameter)
        {
            if (executeMethod != null)
            {
                executeMethod(parameter);
            }

            //now raise CommandCompleted for this ICommand
            WeakActionEvent<object> completedHandler = CommandCompleted;
            if (completedHandler != null)
            {
                completedHandler.Invoke(parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute((T1)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T2)parameter);
        }

#if SILVERLIGHT
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;
#else
        ///// <summary>
        ///// Occurs when changes occur that affect whether the command should execute.
        ///// </summary>
        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        if (canExecuteMethod != null)
        //        {
        //            CommandManager.RequerySuggested += value;
        //        }
        //    }

        //    remove
        //    {
        //        if (canExecuteMethod != null)
        //        {
        //            CommandManager.RequerySuggested -= value;
        //        }
        //    }
        //}
        public event EventHandler CanExecuteChanged;
        private delegate void RaiseExecuteChangedDelegate();
        private void RaiseExcuteChangedVoid()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged.Invoke(this, new EventArgs());
            }
        }
#endif



        /// <summary>
        /// Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "The this keyword is used in the Silverlight version")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate",
            Justification = "This cannot be an event")]
        public void RaiseCanExecuteChanged()
        {
#if SILVERLIGHT
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
#else
            //CommandManager.InvalidateRequerySuggested();
            Application.Current.Dispatcher.BeginInvoke(new RaiseExecuteChangedDelegate(RaiseExcuteChangedVoid));
#endif
        }
    }
    #endregion
}
