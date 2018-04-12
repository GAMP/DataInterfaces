using System;
using System.Globalization;
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

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mask = (int)parameter;
            this.targetValue = (int)value;
            return ((mask & this.targetValue) != 0);
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            this.targetValue ^= (int)parameter;
            return Enum.Parse(targetType, this.targetValue.ToString());
        }
    }
    #endregion
}
