using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class StringEqualNonCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value  == null)
                return false;
            if (parameter == null)
                return false;

            return string.Compare(value.ToString(), parameter.ToString(), true) == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
