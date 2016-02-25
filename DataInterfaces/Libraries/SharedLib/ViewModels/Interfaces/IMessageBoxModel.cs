using System;

namespace SharedLib.ViewModels
{
    public interface IMessageBoxModel
    {
        global::SkinInterfaces.SimpleCommand<object, object> ButtonCommand { get; }
        global::System.Windows.MessageBoxButton Buttons { get; }
        global::SharedLib.NotificationButtons DefaultButton { get; set; }
        bool HideButtons { get; set; }
        global::System.Windows.Media.ImageSource Icon { get; }
        global::System.Windows.Visibility IconVisible { get; }
        global::System.Windows.MessageBoxImage Image { get; }
        string Message { get; }
        global::System.Windows.MessageBoxResult Result { get; }
        string Title { get; }
    }
}
