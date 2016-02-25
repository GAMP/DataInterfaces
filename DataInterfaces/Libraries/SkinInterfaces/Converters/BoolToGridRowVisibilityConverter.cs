using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    public class BoolToGridRowVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue;
            if(value!=null && bool.TryParse(value.ToString(),out boolValue))
            {
               return boolValue == true ? DataGridRowDetailsVisibilityMode.Visible : DataGridRowDetailsVisibilityMode.Collapsed;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
