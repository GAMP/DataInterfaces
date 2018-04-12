using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    /// <summary>
    /// Converts zero values to null.
    /// </summary>
    public class ZeroToNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isOneWay = false;

            if (parameter != null)
                bool.TryParse(parameter.ToString(), out isOneWay);

            if(!isOneWay && value ==null)
                return 0;
         
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int intValue))
                return intValue == 0 ? null : value;

            return value;
        }
    }
}
