using System;
using System.Windows.Input;
using System.Windows;

namespace SkinInterfaces
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

    #region SimpleCommand<T1, T2>
    public class SimpleCommand<T1, T2> : IExecutionChangedAwareCommand,
        ICompletionAwareCommand
    {
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

        #region EVENTS
        public event EventHandler CanExecuteChanged;
        #endregion

        #region FIELDS
        protected Func<T1, bool> canExecuteMethod;
        protected Action<T2> executeMethod;
        #endregion

        #region PROPERTIES
        public WeakActionEvent<object> CommandCompleted { get; set; }
        #endregion

        #region FUNCTIONS

        public virtual bool CanExecute(T1 parameter)
        {
            try
            {
                if (canExecuteMethod == null) return true;
                return canExecuteMethod(parameter);
            }
            catch
            {
                throw;
            }
        }

        public void Execute(T2 parameter)
        {
            try
            {
                executeMethod?.Invoke(parameter);

                WeakActionEvent<object> completedHandler = CommandCompleted;
                if (completedHandler != null)
                    completedHandler.Invoke(parameter);
            }
            catch
            {
                throw;
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            try
            {
                return CanExecute((T1)parameter);
            }
            catch
            {
                throw;
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                Execute((T2)parameter);
            }
            catch
            {
                throw;
            }
        }

        public virtual void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                Application.Current?.Dispatcher.BeginInvoke(handler, this, EventArgs.Empty);
        }

        #endregion
    }
    #endregion
}
