using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class StringCompareMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count() != 2)
                return false;

            var value1 = values[0];
            var value2 = values[1];

            bool ignoreCase = true;
            if(parameter!=null)
                bool.TryParse(parameter.ToString(), out ignoreCase);        

            return string.Compare(value1.ToString(), value2.ToString(), ignoreCase) == 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
