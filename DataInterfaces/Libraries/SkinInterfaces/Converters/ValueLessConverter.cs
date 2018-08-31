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

            var valueType = value.GetType();
            var parameterType = parameter.GetType();

            object convertedValue;
            if (parameterType != valueType)
            {
                var typeConverter = TypeDescriptor.GetConverter(valueType);
                if (!typeConverter.CanConvertFrom(parameterType))
                    return false;

                convertedValue = typeConverter.ConvertFrom(parameter);
            }else
            {
                convertedValue = parameter;
            }

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
