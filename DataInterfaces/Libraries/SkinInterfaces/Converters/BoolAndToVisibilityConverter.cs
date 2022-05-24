using System;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    /// <summary>
    /// Convert multiple value with logical and operation to visibility.
    /// </summary>
    public class BoolAndToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = true;

            foreach (object value in values)
            {
                if ((value is bool) && (bool)value == false)
                {
                    result = false;
                }
            }

            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
