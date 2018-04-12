using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class CountGreaterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = int.Parse(value.ToString());
            int maxValue = int.Parse(parameter.ToString());
            return count > maxValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
