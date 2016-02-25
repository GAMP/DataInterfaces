using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class ZeroToNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value ==null)
            {
                return 0;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = 0;
            if (value != null && int.TryParse(value.ToString(), out intValue))
            {
                return intValue == 0 ? null : value;
            }
            return value;
        }
    }
}
