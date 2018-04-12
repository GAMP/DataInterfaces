using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    /// <summary>
    /// Generic value less converter.
    /// </summary>
    public class ValueLessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            if (parameter == null)
                return false;

            var typeConverter = TypeDescriptor.GetConverter(value.GetType());
            if (!typeConverter.CanConvertFrom(parameter.GetType()))
                return false;

            var convertedValue = typeConverter.ConvertFrom(parameter);

            if (value is IComparable iComparable)
                return iComparable.CompareTo(convertedValue) < 0;         

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
