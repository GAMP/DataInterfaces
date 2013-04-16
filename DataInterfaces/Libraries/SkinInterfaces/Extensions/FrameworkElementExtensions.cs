using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SkinInterfaces
{
    public static class FrameworkElementExtensions
    {
        public static void DoWhenLoaded(this FrameworkElement element, Action action)
        {
            if (element.IsLoaded)
            {
                action();
            }
            else
            {
                RoutedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    element.Loaded -= handler;
                    action();
                };
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
                RoutedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    element.Loaded -= handler;
                    action(element);
                };
                element.Loaded += handler;
            }
        }
    }
}
