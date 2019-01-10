using Microsoft.Xaml.Behaviors;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SkinInterfaces
{
    public class CurrencyTextBehaviour : Behavior<TextBox>
    {
        #region DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MaxDecimalPlacesProperty =
            DependencyProperty.Register(nameof(MaxDecimalPlaces), typeof(int), typeof(CurrencyTextBehaviour),
                                            new FrameworkPropertyMetadata(2));

        [Description("Gets or sets max decimal places.")]
        public int MaxDecimalPlaces
        {
            get { return (int)GetValue(MaxDecimalPlacesProperty); }
            set { SetValue(MaxDecimalPlacesProperty, value); }
        }

        #endregion

        #region OVERRIDES

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += OnLoaded;
            AssociatedObject.TextChanged += OnTextChanged;
            AssociatedObject.PreviewKeyDown += OnPreviewKeyDown;
            AssociatedObject.ContextMenuOpening += OnContextMenuOpening;
            DataObject.AddPastingHandler(AssociatedObject, OnPasting);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Loaded -= OnLoaded;
            AssociatedObject.PreviewKeyDown -= OnPreviewKeyDown;
            AssociatedObject.TextChanged -= OnTextChanged;
            AssociatedObject.ContextMenuOpening -= OnContextMenuOpening;
            DataObject.RemovePastingHandler(AssociatedObject, OnPasting);
        } 

        #endregion

        #region EVENT HANDLERS

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Focus();
            Keyboard.Focus(this.AssociatedObject);
            this.AssociatedObject.CaretIndex = this.AssociatedObject.Text.Length;
        }

        private void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            e.Handled = true;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string groupSeperator = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
            string decimalSeperator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            var tb = this.AssociatedObject;
            using (tb.DeclareChangeBlock())
            {
                foreach (var c in e.Changes)
                {
                    if (c.AddedLength == 0) continue;
                    tb.Select(c.Offset, c.AddedLength);
                    if (tb.SelectedText.Contains(groupSeperator))
                    {
                        tb.SelectedText = tb.SelectedText.Replace(groupSeperator, decimalSeperator);
                    }
                    tb.Select(c.Offset + c.AddedLength, 0);
                }
            }

        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Back || e.Key == Key.Delete;
            var isLetter = e.Key >= Key.A && e.Key <= Key.Z;
            var isComaOrPeriod = e.Key == Key.Decimal | e.Key == Key.OemComma || e.Key == Key.OemPeriod;
            //var isNavigationKey = e.Key == Key.Back; //|| e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down;

            //if (isNavigationKey)
            //    return;

            if (!isNumber && !isComaOrPeriod)
            {
                e.Handled = true;
                return;
            }

            var currentValue = this.AssociatedObject.Text;

            if (string.IsNullOrWhiteSpace(currentValue) && !isComaOrPeriod)
            {
                return;
            }

            if (!decimal.TryParse(currentValue, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal decimalValue))
            {
                e.Handled = true;
                return;
            }

            int count = BitConverter.GetBytes(decimal.GetBits(decimalValue)[3])[2];
            if (count >= this.MaxDecimalPlaces)
            {
                e.Handled = true;
                return;
            }
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        } 

        #endregion
    }
}
