using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    /// <summary>
    /// Converts an empty string value to null.
    /// </summary>
    public class EmptyStringToNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : string.IsNullOrWhiteSpace(value.ToString()) ? null : value;
        }
    }
}
