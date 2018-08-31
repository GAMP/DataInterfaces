using System.Windows;
using System.Windows.Input;

namespace SkinInterfaces
{
    public class MouseBehaviour
    {
        public static readonly DependencyProperty MouseUpCommandProperty =
            DependencyProperty.RegisterAttached("MouseUpCommand", typeof(ICommand),
            typeof(MouseBehaviour), new FrameworkPropertyMetadata(
            new PropertyChangedCallback(MouseUpCommandChanged)));

        private static void MouseUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;

            element.AddHandler(Mouse.MouseEnterEvent, new MouseEventHandler(OnMouseEvent));
            element.AddHandler(Mouse.MouseLeaveEvent, new MouseEventHandler(OnMouseEvent));
        }

        static void OnMouseEvent(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;

            ICommand command = GetMouseUpCommand(element);

            command.Execute(e);
        }

        public static void SetMouseUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseUpCommandProperty, value);
        }

        public static ICommand GetMouseUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseUpCommandProperty);
        }
    }
}
