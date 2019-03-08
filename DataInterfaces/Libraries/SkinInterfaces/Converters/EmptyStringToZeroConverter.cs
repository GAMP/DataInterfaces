using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    /// <summary>
    /// Converts empty string value to zero.
    /// </summary>
    public class EmptyStringToZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return 0;
            }
            return value;
        }
    }
}
