using System;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region BoolToVisibilityConverter
    /// <summary>
    /// Converts bool value to visibility.
    /// <remarks>
    /// If revert operation required specify true as converter parameter.
    /// </remarks>
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is bool)
                {
                    #region Check for revert parameter
                    bool revert = false;
                    if (parameter != null)
                    {
                        if (bool.TryParse(parameter.ToString(), out bool temp))
                        {
                            revert = temp;
                        }
                    }
                    #endregion

                    if ((bool)value == true)
                    {
                        return revert ? Visibility.Collapsed : Visibility.Visible;
                    }
                    else
                    {
                        return revert ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            catch
            {
                return Visibility.Collapsed;
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
