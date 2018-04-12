using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class EmumValueGreaterOrEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int parameterValue = int.Parse(parameter.ToString());
            int enumValue = (int)Enum.Parse(value.GetType(),value.ToString());
            return enumValue >= parameterValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
