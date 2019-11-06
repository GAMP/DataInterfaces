using System.ComponentModel;

namespace System.Threading.Tasks
{
    /// <summary>
    /// Notify completion task.
    /// </summary>
    /// <typeparam name="TResult">Task result type.</typeparam>
    /// <remarks>
    /// Used for making async properties for binding with ViewModel.
    /// </remarks>
    public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="task">Task.</param>
        public NotifyTaskCompletion(Task<TResult> task)
        {
            Task = task ?? throw new ArgumentNullException(nameof(task));
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }
        #endregion

        #region EVENTS

        /// <summary>
        /// Property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets associated task.
        /// </summary>
        public Task<TResult> Task { get; private set; }

        /// <summary>
        /// Gets task result.
        /// </summary>
        public TResult Result
        {
            get
            {
                return (Task.Status == TaskStatus.RanToCompletion) ?
                    Task.Result : default;
            }
        }

        /// <summary>
        /// Gets task status.
        /// </summary>
        public TaskStatus Status { get { return Task.Status; } }

        /// <summary>
        /// Gets if task is completed.
        /// </summary>
        public bool IsCompleted { get { return Task.IsCompleted; } }

        /// <summary>
        /// Gets if task is not completed.
        /// </summary>
        public bool IsNotCompleted { get { return !Task.IsCompleted; } }

        /// <summary>
        /// Gets if task successfully completed.
        /// </summary>
        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status ==
                    TaskStatus.RanToCompletion;
            }
        }

        /// <summary>
        /// Gets if task is cancelled.
        /// </summary>
        public bool IsCanceled { get { return Task.IsCanceled; } }

        /// <summary>
        /// Gets if task is faulted.
        /// </summary>
        public bool IsFaulted { get { return Task.IsFaulted; } }

        /// <summary>
        /// Gets task exception.
        /// </summary>
        public AggregateException Exception { get { return Task.Exception; } }

        /// <summary>
        /// Gets task inner exception.
        /// </summary>
        public Exception InnerException
        {
            get
            {
                return Exception?.InnerException;
            }
        }

        /// <summary>
        /// Gets inner exception message.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return InnerException?.Message;
            }
        }

        #endregion

        #region FUNCTIONS

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
            }

            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;

            propertyChanged(this, new PropertyChangedEventArgs("Status"));
            propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
            propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));

            if (task.IsCanceled)
            {
                propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
            }
            else if (task.IsFaulted)
            {
                propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                propertyChanged(this,
                  new PropertyChangedEventArgs("InnerException"));
                propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
            else
            {
                propertyChanged(this,
                  new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                propertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        #endregion
    }
}
