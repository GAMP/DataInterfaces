using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region NullToEnabledConverter
    /// <summary>
    /// Converts null value to bool.
    /// <remarks>
    /// General goal of converter is to disable visual items if value equals null.
    /// Basic operation is to return false whenever value equals to null and true otherwise.
    /// </remarks>
    /// </summary>
    public class NullToEnabledConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(value == null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion
}
