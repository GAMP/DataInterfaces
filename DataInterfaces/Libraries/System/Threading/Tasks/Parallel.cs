using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace System.Threading.Tasks
{
    /// <summary>
    /// Parallel class extensions.
    /// </summary>
    public static class ParallelEx
    {
        /// <summary>
        /// Invokes event handlers in parallel.
        /// </summary>
        /// <typeparam name="TEventArgs">Event args type.</typeparam>
        /// <param name="sender">Event sender.</param>
        /// <param name="eventHandler">Event handler.</param>
        /// <param name="args">Event arguments instance.</param>
        public static void ParallelInvoke<TEventArgs>(object sender, EventHandler<TEventArgs> eventHandler, TEventArgs args) where TEventArgs : EventArgs
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var invocationList = eventHandler.GetInvocationList()
                .Cast<EventHandler<TEventArgs>>();

            ParallelInvoke(sender, invocationList, args);
        }

        /// <summary>
        /// Invokes event handlers in parallel.
        /// </summary>
        /// <typeparam name="TEventArgs">Event args type.</typeparam>
        /// <param name="sender">Event sender.</param>
        /// <param name="invocationList">Event handlers list.</param>
        /// <param name="args">Event arguments instance.</param>
        public static void ParallelInvoke<TEventArgs>(object sender, IEnumerable<EventHandler<TEventArgs>> invocationList, TEventArgs args) where TEventArgs : EventArgs
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            if (invocationList == null)
                throw new ArgumentNullException(nameof(invocationList));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var exceptions = new ConcurrentQueue<Exception>();
            Parallel.ForEach(invocationList, (e) =>
            {
                try
                {
                    e.Invoke(sender, args);
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }

        public static Task ParallelInvokeAsync<TEventArgs>(object sender, IEnumerable<EventHandler<TEventArgs>> invocationList, TEventArgs args) where TEventArgs : EventArgs
        {
            return Task.Run(() => ParallelInvoke(sender, invocationList, args));
        }

        /// <summary>
        /// Executes for each async.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <returns>Associated task.</returns>
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select Task.Run(async delegate
                {
                    using (partition)
                        while (partition.MoveNext())
                            await body(partition.Current);
                }));
        }
    }
}
