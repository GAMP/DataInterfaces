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
    public class FlagsEnumValueVisibilityConverter : FlagsEnumValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            return (bool)base.Convert(value, targetType, parameter, culture) == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    /// <summary>
    /// Converts flag values to visibility.
    /// <remarks>
    /// General goal of converter is to show UI controls that have their flag set.
    /// The converter should never be shared between multiple UI controls.
    /// </remarks>
    /// </summary>
    public class FlagsEnumValueHiddenConverter : FlagsEnumValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)base.Convert(value, targetType, parameter, culture) == true ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #region RevertFlagsEnumValueVisibilityConverter
    public class RevertFlagsEnumValueVisibilityConverter : FlagsEnumValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)base.Convert(value, targetType, parameter, culture) == true ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
    #endregion
}
