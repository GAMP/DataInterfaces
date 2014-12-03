using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkinInterfaces.Converters
{
    #region FlagsEnumValueConverter
    /// <summary>
    /// Converts flags value to bool.
    /// <remarks>
    /// General goal of converter is to return true for values that have their flags set.
    /// The converter should never be shared between multiple UI controls.
    /// </remarks>
    /// </summary>
    public class FlagsEnumValueConverter : IValueConverter
    {
        private int targetValue;

        public FlagsEnumValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mask = (int)parameter;
            this.targetValue = (int)value;
            return ((mask & this.targetValue) != 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            this.targetValue ^= (int)parameter;
            return Enum.Parse(targetType, parameter.ToString());
        }
    }
    #endregion
}
