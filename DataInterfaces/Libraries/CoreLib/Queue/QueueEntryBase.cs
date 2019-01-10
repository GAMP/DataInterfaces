using System;
using System.Threading;
using SharedLib;
using SkinInterfaces;

namespace CoreLib.Queue
{
    /// <summary>
    /// Abstract queue item implementation.
    /// </summary>
    /// <typeparam name="T">Queue action type.</typeparam>
    public abstract class QueueEntryBase<T> : PropertyChangedBase
    {
        #region FIELDS
        private CancellationTokenSource cancelSource = new CancellationTokenSource();
        private QueuePriority priority;
        private T action;
        private Exception exception;
        private double progress;
        private DateTime time;
        private QueueStatus status;
        private IExecutionChangedAwareCommand
            cancelCommand,
            pauseCommand;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets cancelation token source.
        /// </summary>
        public CancellationTokenSource CancelTokenSource
        {
            get
            {
                return cancelSource;
            }
        }

        /// <summary>
        /// Gets cancelation token.
        /// </summary>
        public CancellationToken CancelToken
        {
            get
            {
                return cancelSource.Token;
            }
        }

        /// <summary>
        /// Gets or sets queue priority.
        /// </summary>
        public QueuePriority Priority
        {
            get { return priority; }
            set { SetProperty(ref priority, value); }
        }

        /// <summary>
        /// Gets or sets queue action.
        /// </summary>
        public T Action
        {
            get { return action; }
            set { SetProperty(ref action, value); }
        }

        /// <summary>
        /// Gets queue status.
        /// </summary>
        public QueueStatus Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        /// <summary>
        /// Gets or sets exception.
        /// </summary>
        public Exception Exception
        {
            get { return exception; }
            set { SetProperty(ref exception, value); }
        }

        /// <summary>
        /// Gets current progress.
        /// </summary>
        public double Progress
        {
            get { return progress; }
            set { SetProperty(ref progress, value); }
        }

        /// <summary>
        /// Gets or sets time.
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        /// <summary>
        /// Gets cancel command.
        /// </summary>
        public IExecutionChangedAwareCommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new SimpleCommand<object, object>(OnCanCancelCommand, OnCancelCommand);
                return cancelCommand;
            }
        }

        /// <summary>
        /// Gets pause command.
        /// </summary>
        public IExecutionChangedAwareCommand PauseCommand
        {
            get
            {
                if (pauseCommand == null)
                    pauseCommand = new SimpleCommand<object, object>(OnCanPauseCommand, OnPauseCommand);
                return pauseCommand;
            }
        }

        #endregion

        #region VIRTUAL

        protected virtual bool OnCanPauseCommand(object param)
        {
            return false;
        }

        protected virtual void OnPauseCommand(object param)
        { }

        protected virtual bool OnCanCancelCommand(object param)
        {
            return !CancelToken.IsCancellationRequested;
        }

        protected virtual void OnCancelCommand(object param)
        {
            CancelTokenSource.Cancel();
        }

        #endregion
    }
}
