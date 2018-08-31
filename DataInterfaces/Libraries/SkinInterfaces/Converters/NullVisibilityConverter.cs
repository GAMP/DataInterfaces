using System;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region NullVisibilityConverter
    /// <summary>
    /// Converts Null to visibility.
    /// This can be used in some components which doesnt need to be displayed if the value they bound to is null.
    /// </summary>
    public class NullVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool revert = false;

            if (parameter != null)
                bool.TryParse(parameter.ToString(), out revert);

            if (value == null)
            {
                return revert ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return revert ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion
}
