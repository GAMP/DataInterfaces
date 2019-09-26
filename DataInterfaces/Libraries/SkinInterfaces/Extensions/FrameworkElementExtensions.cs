using System;
using System.Windows;

namespace SkinInterfaces
{
    public static class FrameworkElementExtensions
    {
        #region FUNCTIONS

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

