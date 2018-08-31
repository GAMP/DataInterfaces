using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SkinInterfaces
{
    public class MediaElementBehaviour : DependencyObject
    {
        #region ATTACHED PROPERTY

        public static DependencyProperty IsPlayingProperty = DependencyProperty.RegisterAttached(
            "IsPlaying",
            typeof(bool),
            typeof(MediaElementBehaviour),
            new PropertyMetadata(false, OnIsPlayingChanged));

        public static DependencyProperty PositionProperty = DependencyProperty.RegisterAttached(
            "Position",
            typeof(TimeSpan),
            typeof(MediaElementBehaviour),
            new PropertyMetadata(new TimeSpan(0), OnPositionChnaged));

        public static readonly DependencyProperty MediaEndedCommandProperty = DependencyProperty.RegisterAttached(
            "MediaEndedCommand",
            typeof(ICommand),
            typeof(MediaElementBehaviour),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnEndedCommandChanged)));

        public static readonly DependencyProperty MediaFailedCommandProperty = DependencyProperty.RegisterAttached(
            "MediaFailedCommand",
            typeof(ICommand),
            typeof(MediaElementBehaviour),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnEndedCommandChanged)));

        #endregion

        public static void SetMediaFailedCommand(UIElement element, ICommand value)
        {
            element.SetValue(MediaFailedCommandProperty, value);
        }
        public static ICommand GetMediaFailedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MediaFailedCommandProperty);
        }

        public static void SetMediaEndedCommand(UIElement element, ICommand value)
        {
            element.SetValue(MediaEndedCommandProperty, value);
        }
        public static ICommand GetMediaEndedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MediaEndedCommandProperty);
        }

        public static void SetPosition(UIElement element, ICommand value)
        {
            element.SetValue(PositionProperty, value);
        }
        public static ICommand GetPosition(UIElement element)
        {
            return (ICommand)element.GetValue(PositionProperty);
        }

        public static bool GetIsPlaying(DependencyObject d)
        {
            return (bool)d.GetValue(IsPlayingProperty);
        }
        public static void SetIsPlaying(DependencyObject d, bool value)
        {
            d.SetValue(IsPlayingProperty, value);
        }

        private static void OnIsPlayingChanged(
            DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (obj is MediaElement element)
            {
                bool isPlaying = (bool)args.NewValue;
                if (isPlaying)
                    element.Play();
                else
                    element.Stop();
            }
        }

        private static void OnPositionChnaged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (obj is MediaElement element)
            {
                element.Position = (TimeSpan)args.NewValue;
            }
        }

        private static void OnEndedCommandChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (obj is MediaElement element)
            {
                element.RemoveHandler(MediaElement.MediaEndedEvent, new RoutedEventHandler(OnMediaEndedEvent));
                element.AddHandler(MediaElement.MediaEndedEvent, new RoutedEventHandler(OnMediaEndedEvent));
            }
        }

        private static void OnMediaFailedCommandChanged(DependencyObject obj,
           DependencyPropertyChangedEventArgs args)
        {
            if (obj is MediaElement element)
            {
                element.RemoveHandler(MediaElement.MediaFailedEvent, new EventHandler<ExceptionRoutedEventArgs>(OnMediaFailedEvent));
                element.AddHandler(MediaElement.MediaFailedEvent, new EventHandler<ExceptionRoutedEventArgs>(OnMediaFailedEvent));
            }
        }

        #region EVENT HANDLERS

        private static void OnMediaFailedEvent(object sender, ExceptionRoutedEventArgs e)
        {
            if (sender is UIElement element)
            {
                var MEDIA_FAILED_COMMAND = GetMediaFailedCommand(element);
                MEDIA_FAILED_COMMAND?.Execute(e);
            }
        }

        private static void OnMediaEndedEvent(object sender, RoutedEventArgs e)
        {
            if (sender is UIElement element)
            {
                var MEDIA_ENDED_COMMAND = GetMediaEndedCommand(element);
                MEDIA_ENDED_COMMAND?.Execute(e);
            }
        } 

        #endregion
    }
}
