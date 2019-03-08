using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region NullToHiddenConverter
    /// <summary>
    /// Converts null value to hidden visibility.
    /// </summary>
    public class NullToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool revert = false;

            if (parameter != null)
                bool.TryParse(parameter.ToString(), out revert);

            if (value == null)
            {
                return revert ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                return revert ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
    #endregion
}
