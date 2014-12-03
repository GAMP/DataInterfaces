using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region FlagsEnumValueVisibilityConverter
    /// <summary>
    /// Converts flag values to visibility.
    /// <remarks>
    /// General goal of converter is to show UI controls that have their flag set.
    /// The converter should never be shared between multiple UI controls.
    /// </remarks>
    /// </summary>
    public class FlagsEnumValueVisibilityConverter : IValueConverter
    {
        private int targetValue;

        public FlagsEnumValueVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mask = (int)parameter;
            this.targetValue = (int)value;
            return  (((mask & this.targetValue) != 0)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
