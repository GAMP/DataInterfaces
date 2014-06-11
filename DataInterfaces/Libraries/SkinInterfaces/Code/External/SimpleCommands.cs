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
        WeakActionEvent<object> CommandCompleted { get; set; }
    }

    public interface IExecutionChangedAwareCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
    #endregion

    #region SimpleCommand
    public class SimpleCommand<T1, T2> : IExecutionChangedAwareCommand, ICompletionAwareCommand
    {
        #region FIELDS
        protected Func<T1, bool> canExecuteMethod;
        protected Action<T2> executeMethod;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region CONSTRUCTOR

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

        #endregion

        #region PROPERTIES
        public WeakActionEvent<object> CommandCompleted { get; set; }
        #endregion

        #region FUNCTIONS

        public virtual bool CanExecute(T1 parameter)
        {
            if (canExecuteMethod == null) return true;
            return canExecuteMethod(parameter);
        }

        public void Execute(T2 parameter)
        {
            if (executeMethod != null)
                executeMethod(parameter);

            WeakActionEvent<object> completedHandler = CommandCompleted;
            if (completedHandler != null)
                completedHandler.Invoke(parameter);

        }

        public virtual bool CanExecute(object parameter)
        {
            return CanExecute((T1)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T2)parameter);
        }

        public virtual void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
                Application.Current.Dispatcher.BeginInvoke(handler, this, EventArgs.Empty);
        }
        
        #endregion
    }
    #endregion
}
