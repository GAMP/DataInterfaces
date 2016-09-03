using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region EnumToBoolConverter
    /// <summary>
    /// Goal of converter is to determine if current value equals enum value.
    /// </summary>
    public class EnumToBoolConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals(value, Enum.Parse(parameter.GetType(), parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Enum.Parse(parameter.GetType(), parameter.ToString()) : Enum.ToObject(parameter.GetType(), 0);
        }
    }
    #endregion  
}
