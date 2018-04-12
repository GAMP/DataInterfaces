using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region ValueNullToBoolConverter
    /// <summary>
    /// Checks value for null condition and returns true if value is null otherwise false.
    /// </summary>
    public class ValueNullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
    #endregion
}
