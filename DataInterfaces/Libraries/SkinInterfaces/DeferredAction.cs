using System;
using System.Threading;
using System.Windows;

namespace SkinInterfaces
{
    #region DeferredAction
    /// <summary>
    /// Represents a timer which performs an action on the UI thread when time elapses.  Rescheduling is supported.
    /// </summary>
    public class DeferredAction : IDisposable
    {
        #region FIELDS
        private Timer timer;
        #endregion

        #region FUNCTIONS

        #region STATIC

        /// <summary>
        /// Creates a new DeferredAction.
        /// </summary>
        /// <param name="action">
        /// The action that will be deferred.  It is not performed until after <see cref="Defer"/> is called.
        /// </param>
        public static DeferredAction Create(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new DeferredAction(action);
        }

        #endregion

        #region PRIVATE

        private DeferredAction(Action action)
        {
            timer = new Timer(new TimerCallback(delegate
            {
                Application.Current?.Dispatcher.Invoke(action);
            }));
        }

        #endregion

        #region PUBLIC

        /// <summary>
        /// Defers performing the action until after time elapses.  Repeated calls will reschedule the action
        /// if it has not already been performed.
        /// </summary>
        /// <param name="delay">
        /// The amount of time to wait before performing the action.
        /// </param>
        public void Defer(TimeSpan delay)
        {
            // Fire action when time elapses (with no subsequent calls).
            timer?.Change(delay, TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        /// Cancells deferred action.
        /// </summary>
        public void Cancel()
        {
            timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #endregion

        #endregion

        #region IDisposable

        public void Dispose()
        {
            timer?.Dispose();
            timer = null;
        }

        #endregion
    }
    #endregion
}
