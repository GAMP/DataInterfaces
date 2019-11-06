using System;
using System.Windows;

namespace SkinInterfaces
{
    /// <summary>
    /// Framework element extensions.
    /// </summary>
    public static class FrameworkElementExtensions
    {
        #region FUNCTIONS

        /// <summary>
        /// Executs action once famework element is loaded.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="action">Action.</param>
        public static void DoWhenLoaded(this FrameworkElement element, Action action)
        {
            if (element.IsLoaded)
            {
                action();
            }
            else
            {
                void handler(object sender, RoutedEventArgs e)
                {
                    element.Loaded -= handler;
                    action();
                }

                element.Loaded += handler;
            }
        }

        /// <summary>
        /// Executs action once famework element is loaded.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="element">Element.</param>
        /// <param name="action">Action.</param>
        public static void DoWhenLoaded<T>(this T element, Action<T> action)
            where T : FrameworkElement
        {
            if (element.IsLoaded)
            {
                action(element);
            }
            else
            {
                void handler(object sender, RoutedEventArgs e)
                {
                    element.Loaded -= handler;
                    action(element);
                }

                element.Loaded += handler;
            }
        }

        #endregion
    }
}

