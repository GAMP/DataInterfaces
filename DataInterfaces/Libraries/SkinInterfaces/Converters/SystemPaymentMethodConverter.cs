using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class SystemPaymentMethodConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            int id = int.Parse(value.ToString());
            return id > -999 && id < 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
