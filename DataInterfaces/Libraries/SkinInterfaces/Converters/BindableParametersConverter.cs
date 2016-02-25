using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace SkinInterfaces
{
    #region BindableParametersConverter
    public abstract class BindableParametersConverter : DependencyObject, IValueConverter
    {
        #region Fields
        public static DependencyProperty BindableConverterParameterProperty = DependencyProperty.Register("BindableConverterParameter", typeof(object),
          typeof(BindableParametersConverter));
        #endregion

        #region Properties
        [Description("Gets or sets converter parameter")]
        public object BindableConverterParameter
        {
            get { return (object)GetValue(BindableConverterParameterProperty); }
            set { SetValue(BindableConverterParameterProperty, value); }
        }
        #endregion

        #region Abstract Members

        public abstract object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        #endregion
    }
    #endregion
}
