using System;
using System.Globalization;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region StringEnvrionmentConverter
    /// <summary>
    /// Convertes string to environment expanded string.
    /// </summary>
    public class StringToEnvrionmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
                return Environment.ExpandEnvironmentVariables(value.ToString());
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
