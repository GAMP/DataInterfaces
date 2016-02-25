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
                return this.cancelSource;
            }
        }

        /// <summary>
        /// Gets cancelation token.
        /// </summary>
        public CancellationToken CancelToken
        {
            get
            {
                return this.cancelSource.Token;
            }
        }

        /// <summary>
        /// Gets or sets queue priority.
        /// </summary>
        public QueuePriority Priority
        {
            get { return this.priority; }
            set { this.SetProperty(ref this.priority, value); }
        }

        /// <summary>
        /// Gets or sets queue action.
        /// </summary>
        public T Action
        {
            get { return this.action; }
            set { this.SetProperty(ref this.action, value); }
        }

        /// <summary>
        /// Gets queue status.
        /// </summary>
        public QueueStatus Status
        {
            get { return this.status; }
            set { this.SetProperty(ref this.status, value); }
        }

        /// <summary>
        /// Gets or sets exception.
        /// </summary>
        public Exception Exception
        {
            get { return this.exception; }
            set { this.SetProperty(ref this.exception, value); }
        }

        /// <summary>
        /// Gets current progress.
        /// </summary>
        public double Progress
        {
            get { return this.progress; }
            set { this.SetProperty(ref this.progress, value); }
        }

        /// <summary>
        /// Gets or sets time.
        /// </summary>
        public DateTime Time
        {
            get { return this.time; }
            set { this.SetProperty(ref this.time, value); }
        }

        /// <summary>
        /// Gets cancel command.
        /// </summary>
        public IExecutionChangedAwareCommand CancelCommand
        {
            get
            {
                if (this.cancelCommand == null)
                    this.cancelCommand = new SimpleCommand<object, object>(OnCanCancelCommand, OnCancelCommand);
                return this.cancelCommand;
            }
        }

        /// <summary>
        /// Gets pause command.
        /// </summary>
        public IExecutionChangedAwareCommand PauseCommand
        {
            get
            {
                if (this.pauseCommand == null)
                    this.pauseCommand = new SimpleCommand<object, object>(OnCanPauseCommand, OnPauseCommand);
                return this.pauseCommand;
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
            return !this.CancelToken.IsCancellationRequested;
        }
        protected virtual void OnCancelCommand(object param)
        {
            this.CancelTokenSource.Cancel();
        }

        #endregion
    }
}
