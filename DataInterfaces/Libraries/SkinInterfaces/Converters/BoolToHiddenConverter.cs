using System;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region BoolToHiddenConverter
    /// <summary>
    /// Converts bool value to visibility.
    /// <remarks>If revert operation required specify true as converter parameter.</remarks>
    /// </summary>
    public class BoolToHiddenConverter : IValueConverter
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
                        bool temp;
                        if (bool.TryParse(parameter.ToString(), out temp))
                        {
                            revert = temp;
                        }
                    }
                    #endregion

                    if ((bool)value == true)
                    {
                        return revert ? Visibility.Hidden : Visibility.Visible;
                    }
                    else
                    {
                        return revert ? Visibility.Visible : Visibility.Hidden;
                    }
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
            catch
            {
                return Visibility.Hidden;
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
