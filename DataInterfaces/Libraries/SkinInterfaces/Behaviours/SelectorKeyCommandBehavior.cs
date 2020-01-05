using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Xaml.Behaviors;

namespace SkinInterfaces
{
    public class SelectorKeyUpCommandBehavior : Behavior<Selector>
    {
        #region Overrides

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyUp+=new KeyEventHandler(AssociatedObject_KeyUp);
            EnableDisableElement();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyUp -= new KeyEventHandler(AssociatedObject_KeyUp);
        }


        #endregion

        #region Private Methods

        private void AssociatedObject_KeyUp(object sender, KeyEventArgs e)
        {   //Get the ItemsControl and then get the item, and check there
            //is an actual item, as if we are using a ListView we may have clicked the
            //headers which are not items
            ItemsControl listView = sender as ItemsControl;
            DependencyObject originalSender = e.OriginalSource as DependencyObject;
            if (listView == null || originalSender == null) return;

            DependencyObject container =
                ItemsControl.ContainerFromElement
                (sender as ItemsControl, e.OriginalSource as DependencyObject);

            if (container == null ||
                container == DependencyProperty.UnsetValue) return;

            // found a container, now find the item.
            object activatedItem =
                listView.ItemContainerGenerator.ItemFromContainer(container);

            if (activatedItem != null)
            {
                Invoke(activatedItem, e);
            }
        }

        private static void OnCommandChanged(SelectorKeyUpCommandBehavior thisBehaviour, 
            DependencyPropertyChangedEventArgs e)
        {
            if (thisBehaviour == null)
            {
                return;
            }

            if (e.OldValue != null)
            {
                ((ICommand)e.OldValue).CanExecuteChanged -= thisBehaviour.OnCommandCanExecuteChanged;
            }

            ICommand command = (ICommand)e.NewValue;

            if (command != null)
            {
                command.CanExecuteChanged += thisBehaviour.OnCommandCanExecuteChanged;
            }

            thisBehaviour.EnableDisableElement();
        }

        private bool IsAssociatedElementDisabled()
        {
            return AssociatedObject != null && !AssociatedObject.IsEnabled;
        }

        private void EnableDisableElement()
        {
            if (AssociatedObject == null || Command == null)
            {
                return;
            }

            AssociatedObject.IsEnabled = Command.CanExecute(this.CommandParameter);
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            EnableDisableElement();
        }

        #endregion

        #region Protected Methods
        /// <param name="clickedItem">The EventArgs of the fired event.</param>
        /// <param name="parameter">Parameter.</param>
        protected void Invoke(object clickedItem, KeyEventArgs parameter)
        {
            if (IsAssociatedElementDisabled())
            {
                return;
            }

            ICommand command = Command;
            if (command != null && command.CanExecute(CommandParameter))
            {
                command.Execute(new EventToCommandArgs(clickedItem, command,
                    CommandParameter, (EventArgs)parameter));
            }
        }
        #endregion

        #region DPs

        #region CommandParameter
        /// <summary>
        /// Identifies the <see cref="CommandParameter" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter", typeof(object), typeof(SelectorKeyUpCommandBehavior),
            new PropertyMetadata(null,
                (s, e) =>
                {
                    SelectorKeyUpCommandBehavior sender = s as SelectorKeyUpCommandBehavior;
                    if (sender == null)
                    {
                        return;
                    }

                    if (sender.AssociatedObject == null)
                    {
                        return;
                    }

                    sender.EnableDisableElement();
                }));


        /// <summary>
        /// Gets or sets an object that will be passed to the <see cref="Command" />
        /// attached to this trigger. This is a DependencyProperty.
        /// </summary>
        public object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        #endregion

        #region Command
        /// <summary
        /// >
        /// Identifies the <see cref="Command" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(SelectorKeyUpCommandBehavior),
            new PropertyMetadata(null,
                (s, e) => OnCommandChanged(s as SelectorKeyUpCommandBehavior, e)));


        /// <summary>
        /// Gets or sets the ICommand that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #endregion
    }

    public class SelectorKeyDownCommandBehavior : Behavior<Selector>
    {
        #region Overrides

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += new KeyEventHandler(AssociatedObject_KeyDown);
            EnableDisableElement();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= new KeyEventHandler(AssociatedObject_KeyDown);
        }

        #endregion

        #region Private Methods

        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {   //Get the ItemsControl and then get the item, and check there
            //is an actual item, as if we are using a ListView we may have clicked the
            //headers which are not items
            ItemsControl listView = sender as ItemsControl;
            DependencyObject originalSender = e.OriginalSource as DependencyObject;
            if (listView == null || originalSender == null) return;

            DependencyObject container =
                ItemsControl.ContainerFromElement
                (sender as ItemsControl, e.OriginalSource as DependencyObject);

            if (container == null ||
                container == DependencyProperty.UnsetValue) return;

            // found a container, now find the item.
            object activatedItem =
                listView.ItemContainerGenerator.ItemFromContainer(container);

            if (activatedItem != null)
            {
                Invoke(activatedItem, e);
            }

        }

        private static void OnCommandChanged(SelectorKeyDownCommandBehavior thisBehaviour,
            DependencyPropertyChangedEventArgs e)
        {
            if (thisBehaviour == null)
            {
                return;
            }

            if (e.OldValue != null)
            {
                ((ICommand)e.OldValue).CanExecuteChanged -= thisBehaviour.OnCommandCanExecuteChanged;
            }

            ICommand command = (ICommand)e.NewValue;

            if (command != null)
            {
                command.CanExecuteChanged += thisBehaviour.OnCommandCanExecuteChanged;
            }

            thisBehaviour.EnableDisableElement();
        }

        private bool IsAssociatedElementDisabled()
        {
            return AssociatedObject != null && !AssociatedObject.IsEnabled;
        }

        private void EnableDisableElement()
        {
            if (AssociatedObject == null || Command == null)
            {
                return;
            }

            AssociatedObject.IsEnabled = Command.CanExecute(this.CommandParameter);
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            EnableDisableElement();
        }

        #endregion

        #region Protected Methods
        /// <param name="clickedItem">The EventArgs of the fired event.</param>
        /// <param name="parameter">Parameter.</param>
        protected void Invoke(object clickedItem, KeyEventArgs parameter)
        {
            if (IsAssociatedElementDisabled())
            {
                return;
            }

            ICommand command = Command;
            if (command != null && command.CanExecute(CommandParameter))
            {
                command.Execute(new EventToCommandArgs(clickedItem, command,
                    CommandParameter, (EventArgs)parameter));
            }
        }
        #endregion

        #region DPs

        #region CommandParameter
        /// <summary>
        /// Identifies the <see cref="CommandParameter" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter", typeof(object), typeof(SelectorKeyDownCommandBehavior),
            new PropertyMetadata(null,
                (s, e) =>
                {
                    SelectorKeyDownCommandBehavior sender = s as SelectorKeyDownCommandBehavior;
                    if (sender == null)
                    {
                        return;
                    }

                    if (sender.AssociatedObject == null)
                    {
                        return;
                    }

                    sender.EnableDisableElement();
                }));


        /// <summary>
        /// Gets or sets an object that will be passed to the <see cref="Command" />
        /// attached to this trigger. This is a DependencyProperty.
        /// </summary>
        public object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        #endregion

        #region Command
        /// <summary
        /// >
        /// Identifies the <see cref="Command" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(SelectorKeyDownCommandBehavior),
            new PropertyMetadata(null,
                (s, e) => OnCommandChanged(s as SelectorKeyDownCommandBehavior, e)));


        /// <summary>
        /// Gets or sets the ICommand that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #endregion
    }
}