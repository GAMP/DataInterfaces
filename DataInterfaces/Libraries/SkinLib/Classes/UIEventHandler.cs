using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Client;
using System.Windows.Media.Animation;
using System.Windows.Media;
using SkinInterfaces;
using System.Windows.Controls;

namespace SkinLib
{
    public static class EventHandlers
    {
        #region Zindexing

        /// <summary>
        /// Handles MouseDown event over control so its zindex can be adjusted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        public static void ZindexChangeEvent(object sender, RoutedEventArgs e)
        {
            //Find sender visual parent
            Panel VisualParent = VisualTreeHelper.GetParent((DependencyObject)sender) as Panel;
            if (VisualParent == null)
            {
                return;
            }
            UIElement CurrentTopObject = default(UIElement);
            int CurrentTopIndex = 0;
            foreach (UIElement Child in VisualParent.Children)
            {
                int UiElementZindex = (int)Child.GetValue(Canvas.ZIndexProperty);
                if (UiElementZindex >= CurrentTopIndex)
                {
                    CurrentTopIndex = UiElementZindex;
                    CurrentTopObject = Child;
                }
            }
            if (CurrentTopIndex == 0)
            {
                CurrentTopIndex = 1;
            }
            else
            {
                foreach (UIElement Child in VisualParent.Children)
                    Child.SetValue(Canvas.ZIndexProperty, (int)Child.GetValue(Canvas.ZIndexProperty) - 1);                
            }
            Canvas.SetZIndex(sender as UIElement, CurrentTopIndex);
            e.Handled = false;
        }
        
        #endregion

        #region Visual States

        public static void VisualStateChanged(FrameworkElement sender, DependencyPropertyChangedEventArgs e)
        {
            #region Minimized
            if ((ElementVisualState)e.NewValue == ElementVisualState.Minimized)
            {
                sender.Freeze();
                ScaleTransform TransformScale = new ScaleTransform();
                DoubleAnimation Animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(250));
                Animation.SetValue(Storyboard.TargetProperty, sender);
                Animation.FillBehavior = FillBehavior.HoldEnd;
                Timeline.SetDesiredFrameRate(Animation, 100);
                ((UIElement)sender).SetValue(UserControl.RenderTransformProperty, TransformScale);
                ((UIElement)sender).BeginAnimation(UserControl.OpacityProperty, Animation, HandoffBehavior.SnapshotAndReplace);
                ((UIElement)sender).RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                TransformScale.BeginAnimation(ScaleTransform.ScaleYProperty, Animation, HandoffBehavior.Compose);
                TransformScale.BeginAnimation(ScaleTransform.ScaleXProperty, Animation, HandoffBehavior.Compose);

                //If element not maximized then set the restore visuals
                if ((sender.IsMaximized() == false))
                    sender.SaveVisuals();
               
            }
            #endregion

            #region Normal
            else if ((ElementVisualState)e.NewValue == ElementVisualState.Normal)
            {
                if ((ElementVisualState)e.OldValue == ElementVisualState.Minimized |
                    (ElementVisualState)e.OldValue == ElementVisualState.Closed)
                {
                    //if element is in maximized state then simply maximize it
                    if (sender.IsMaximized() == true)
                    {
                        SkinHelper.SetVisualState(SkinInterfaces.ElementVisualState.Maximized, sender);
                    }
                    if ((SkinInterfaces.ElementVisualState)e.OldValue == SkinInterfaces.ElementVisualState.Closed)
                    {
                        sender.Visibility = Visibility.Visible;
                    }
                    DoubleAnimation Animation = new DoubleAnimation();
                    if ((((FrameworkElement)sender).RestoreVisuals() != null))
                    {
                        Animation.To = ((FrameworkElement)sender).RestoreVisuals().Opacity;
                    }
                    else
                    {
                        Animation.To = 1;
                    }
                    Animation.Duration = TimeSpan.FromMilliseconds(250);
                    Animation.FillBehavior = FillBehavior.Stop;
                    Animation.SetValue(Storyboard.TargetProperty, sender);
                    Animation.Completed += EventHandlers.OnRestoreAnimationComplete;
                    ((UIElement)sender).BeginAnimation(UserControl.OpacityProperty, Animation, HandoffBehavior.SnapshotAndReplace);
                    ScaleTransform TransformScale = new ScaleTransform();
                    DoubleAnimation ScaleAnimation = new DoubleAnimation();
                    ScaleAnimation.FillBehavior = FillBehavior.Stop;
                    ScaleAnimation.From = 0.0;
                    ScaleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(250));
                    sender.RenderTransform = TransformScale;
                    sender.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                    TransformScale.BeginAnimation(ScaleTransform.ScaleXProperty, ScaleAnimation, HandoffBehavior.Compose);
                    TransformScale.BeginAnimation(ScaleTransform.ScaleYProperty, ScaleAnimation, HandoffBehavior.Compose);
                }
                else if ((ElementVisualState)e.OldValue == ElementVisualState.Maximized)
                {
                    sender.Restore();
                    sender.IsMaximized(false);
                    sender.UnFreeze();
                }
                else
                {
                    if (sender.IsMaximized())
                        sender.SaveVisuals();                  
                }
            }
            #endregion

            #region Closed
            else if ((SkinInterfaces.ElementVisualState)e.NewValue == SkinInterfaces.ElementVisualState.Closed)
            {
                ScaleTransform TransformScale = new ScaleTransform();
                DoubleAnimation Animation = new DoubleAnimation(0.0, TimeSpan.FromMilliseconds(250));
                Animation.Completed += EventHandlers.OnCloseAnimationComplete;
                Animation.SetValue(Storyboard.TargetProperty, sender);
                ((UIElement)sender).SetValue(UserControl.RenderTransformProperty, TransformScale);
                ((UIElement)sender).BeginAnimation(UserControl.OpacityProperty, Animation, HandoffBehavior.SnapshotAndReplace);
                sender.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                TransformScale.BeginAnimation(ScaleTransform.ScaleXProperty, Animation, HandoffBehavior.Compose);
                TransformScale.BeginAnimation(ScaleTransform.ScaleYProperty, Animation, HandoffBehavior.Compose);

                //If element not maximized then set the restore visuals
                if (sender.IsMaximized())
                    sender.SaveVisuals();                
            }
            #endregion

            #region Maximized
            else if ((SkinInterfaces.ElementVisualState)e.NewValue == SkinInterfaces.ElementVisualState.Maximized)
            {
                if ((ElementVisualState)e.OldValue == ElementVisualState.Normal)
                {
                    if (!sender.IsMaximized())
                        sender.SaveVisuals();                    
                }
                if ((ElementVisualState)e.OldValue == ElementVisualState.Closed)
                {
                    if (!sender.IsMaximized())
                        sender.SaveVisuals();                   
                    sender.Visibility = Visibility.Visible;
                }

                sender.Freeze();
                SkinHelper.Maximize(sender);
                sender.IsMaximized(true);
            }
            #endregion
        }
        
        #endregion

        #region Event Handlers
       
        public static void DependencyPropertyChangeHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                #region Active
                if (object.ReferenceEquals(e.Property, InternalProperties.IsActiveElementProperty))
                {
                    //Set the current active ellement
                    if ((bool)e.NewValue == true)
                    {
                        if ((UIHandler.Current.CurrentLayout != null))
                        {
                            if ((UIHandler.Current.ActiveControl != null))
                                ((FrameworkElement)UIHandler.Current.ActiveControl).IsActive(false);                           
                            UIHandler.Current.ActiveControl = sender as UserControl;
                        }
                    }
                }
                #endregion
                #region AllowZindex
                else if (object.ReferenceEquals(e.Property, ExternalProperties.AllowZindexProperty))
                {
                    if ((bool)e.OldValue == false & (bool)e.NewValue == true)
                    {
                        ((FrameworkElement)sender).IsZIndexEnabled(true);
                        ((FrameworkElement)sender).AddHandler(System.Windows.Controls.Button.MouseLeftButtonDownEvent,
                            new RoutedEventHandler(EventHandlers.ZindexChangeEvent), true);
                    }
                    else if ((bool)e.OldValue == true & (bool)e.NewValue == false)
                    {
                        ((FrameworkElement)sender).IsZIndexEnabled(false);
                        ((FrameworkElement)sender).RemoveHandler(Button.MouseLeftButtonDownEvent,
                            new RoutedEventHandler(EventHandlers.ZindexChangeEvent));
                    }
                }
                else if (object.ReferenceEquals(e.Property, ExternalProperties.VisualStateProperty))
                {
                    EventHandlers.VisualStateChanged(sender as FrameworkElement, e);
                }
                #endregion
            }
            catch
            { 
                //ignore for now
            }

        }
       
        private static void OnCloseAnimationComplete(object sender, EventArgs e)
        {
            UIElement target = ((AnimationClock)sender).Timeline.GetValue(Storyboard.TargetProperty) as UIElement;
            if (target != null)
            {
                ((FrameworkElement)target).Visibility = Visibility.Collapsed;
                SkinHelper.SetVisualState(SkinInterfaces.ElementVisualState.Closed, (FrameworkElement)target);
            }
        }

        private static void OnRestoreAnimationComplete(object sender, EventArgs e)
        {
            UIElement Target = ((Clock)sender).Timeline.GetValue(Storyboard.TargetProperty) as UIElement;
            if (Target.IsMaximized() == false)
                Target.UnFreeze();
            
        }

        #endregion
    }
}
