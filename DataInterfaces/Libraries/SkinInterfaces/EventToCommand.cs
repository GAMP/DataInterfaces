using System.Windows;
using System.Windows.Input;

namespace SkinInterfaces
{
    public class EventToCommand
    {
        #region COMMAND 

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(EventToCommand), new UIPropertyMetadata(null));

        #endregion

        #region COMMANDPARAMETER 

        public static object GetCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(EventToCommand), new UIPropertyMetadata(null));

        #endregion

        #region EVENT 

        public static RoutedEvent GetEvent(DependencyObject obj)
        {
            return (RoutedEvent)obj.GetValue(EventProperty);
        }

        public static void SetEvent(DependencyObject obj, RoutedEvent value)
        {
            obj.SetValue(EventProperty, value);
        }

        public static readonly DependencyProperty EventProperty =
            DependencyProperty.RegisterAttached("Event", typeof(RoutedEvent), typeof(EventToCommand), new UIPropertyMetadata(null, EventChanged));

        #endregion

        static void EventChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is UIElement ele)
            {
                if (e.NewValue!=null)
                    ele.AddHandler((RoutedEvent)e.NewValue, new RoutedEventHandler(DoCommand));
            }
        }

        static void DoCommand(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement ele)
            {
                var command = (ICommand)ele.GetValue(CommandProperty);
                if (command != null)
                {
                    var parameter = ele.GetValue(CommandParameterProperty);
                    parameter = parameter ?? e;
                    command.Execute(parameter);
                }
            }
        }
    }
}
