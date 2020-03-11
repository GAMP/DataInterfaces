using System;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Documents;
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using CoreLib;
using SharedLib.ViewModels;
using SharedLib;
using CyClone.Core;
using System.Windows.Markup;
using IntegrationLib;
using System.Reflection;

namespace SkinInterfaces.Converters
{
    #region RevertBoolConverter
    /// <summary>
    /// Reverts bool value.
    /// </summary>
    public class RevertBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        #endregion
    }
    #endregion

    #region BoolToStringConverter
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            if (!String.IsNullOrWhiteSpace(val))
            {
                if (val.ToLower() == "yes")
                {
                    return true;
                }
                else if (val.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return "Unknown";
            }
        }
    }
    #endregion

    #region DoubleSecondsToHoursConverter
    public class DoubleSecondsToHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan span = TimeSpan.FromSeconds((double)value);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)span.TotalHours, span.Minutes, span.Seconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region TimeSpanConverter
    public class TimeSpanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is TimeSpan span)
                {
                    string spanString = span.ToString();
                    if (spanString.LastIndexOf(".") != -1)
                    {
                        return spanString.Substring(0, spanString.LastIndexOf("."));
                    }
                    else
                    {
                        return spanString;
                    }
                }
                return value;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region BytesConverter
    public class BytesConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                long bytes = long.Parse(value.ToString());
                return FormatBytes(bytes);
            }
            catch
            {
                return value;
            }
        }

        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.00} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region BytesToMegabyesConverter
    /// <summary>
    /// Converts bytes value amount to megabytes.
    /// </summary>
    public class BytesToMegabyesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var bytes = 0;
                if (int.TryParse(value.ToString(), out bytes))
                {
                    return bytes / 1024 / 1024;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var megaBytes = 0;
                if (int.TryParse(value.ToString(), out megaBytes))
                {
                    if (megaBytes > 0)
                    {
                        return megaBytes * 1024 * 1024;
                    }
                    else
                    {
                        return megaBytes;
                    }
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }
    }
    #endregion

    #region PopupHorizontalOffsetConverter
    public class PopupHorizontalOffsetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values != null)
                {
                    if (values[0] != DependencyProperty.UnsetValue &
                        values[1] != DependencyProperty.UnsetValue &
                        values[0] != null &
                        values[1] != null)
                    {
                        bool isOpen = (bool)values[0];
                        if (values[1] is Popup)
                        {
                            Popup popup = values[1] as Popup;
                            if (popup.Child != null)
                            {
                                double contentCenter = popup.Child.RenderSize.Width / 2;
                                double popupCenter = popup.PlacementTarget.RenderSize.Width / 2;
                                return (Double)(popupCenter - contentCenter);
                            }
                        }
                        else if (values[1] is ToolTip)
                        {
                            ToolTip popup = values[1] as ToolTip;
                            if (popup.PlacementTarget != null)
                            {
                                double contentCenter = popup.RenderSize.Width / 2;
                                double popupCenter = popup.PlacementTarget.RenderSize.Width / 2;
                                return (Double)(popupCenter - contentCenter);
                            }
                        }
                    }
                }
            }
            catch
            { }
            return (Double)0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region DimensionsConverter
    public class DimensionsConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (double.IsNaN((double)value))
            {
                return -1;
            }
            else if (double.IsInfinity((double)value))
            {
                return -2;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleval = double.NaN;
            if (double.TryParse(value.ToString(), out doubleval))
            {
                if (doubleval == -1)
                {
                    return double.NaN;
                }
                if (doubleval == -2)
                {
                    return double.PositiveInfinity;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return double.NaN;
            }

        }

        #endregion
    }
    #endregion

    #region CountToVisibilityConverter
    public class CountToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return Visibility.Collapsed;

                if (value is int? && (int?)(value) > 0)
                    return Visibility.Visible;

                if (value is int && (int)(value) > 0)
                    return Visibility.Visible;

                return Visibility.Collapsed;
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

    #region CountToHiddenConverter
    public class CountToHiddenConverter : CountToVisibilityConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)base.Convert(value, targetType, parameter, culture) == Visibility.Collapsed ? Visibility.Hidden : Visibility.Visible;
        }
    }
    #endregion

    #region CountToBoolConverter
    public class CountToBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return false;

                int countValue;

                if (!int.TryParse(value.ToString(), out countValue))
                    return false;

                bool reverseValue = false;

                if (parameter != null)
                    bool.TryParse(parameter.ToString(), out reverseValue);

                return reverseValue ? countValue <= 0 : countValue > 0;

            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion    

    #region FallBackConverter
    public class FallBackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value ?? parameter;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region HiddenToOpacityConverter
    public class HiddenToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool revert = false;
            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out revert);
            }

            if ((bool)value == true)
            {
                return revert ? 1 : 0.5;
            }
            else
            {
                return revert ? 0.5 : 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region MinDateToVisibilityConverter
    /// <summary>
    /// Converts DateTime to Visibility.
    /// <remarks>If DateTime equals to MinDate Collapsed returned else Visible returned.</remarks>
    /// </summary>
    public class MinDateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                return ((DateTime)value) == DateTime.MinValue | ((DateTime)value) == DateTime.MaxValue ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion 

    #region DateTimeToDateConverter
    /// <summary>
    /// Converts DateTime values to a short date string.
    /// </summary>
    public class DateTimeToDateConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion    

    #region EmptyPathConverter
    public class EmptyPathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty((value as string)))
            {
                return null;
            }
            else
            {
                string s = (value as string).Trim();
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty((value as string)))
            {
                return null;
            }
            else
            {
                string s = (value as string).Trim();
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
        }

        #endregion
    }
    #endregion

    #region ImageByteToBitmapSourceConverter
    /// <summary>
    /// Converts image byte array value to an bitmap image value. 
    /// </summary>
    public class ImageByteToBitmapSourceConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte[] data = value as byte[];
            try
            {
                if (data != null)
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(data);
                    image.EndInit();
                    return image;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region RegistryHiveConverter
    /// <summary>
    /// Converts a RegistryHive values to a numeric integer values.
    /// </summary>
    public class RegistryHiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                RegistryHive hive = (RegistryHive)value;
                switch (hive)
                {
                    case RegistryHive.ClassesRoot:
                        return 0;
                    case RegistryHive.CurrentUser:
                        return 1;
                    case RegistryHive.LocalMachine:
                        return 2;
                    case RegistryHive.Users:
                        return 3;
                    case RegistryHive.CurrentConfig:
                        return 4;
                    case RegistryHive.PerformanceData:
                        return 5;

                    //TODO: MIGRATION: Core API does not contain this value
#if NETFRAMEWORK
                    case RegistryHive.DynData:
                        return 6;
#endif

                    default:
                        return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int index = (int)value;
                switch (index)
                {
                    case 0:
                        return RegistryHive.ClassesRoot;
                    case 1:
                        return RegistryHive.CurrentUser;
                    case 2:
                        return RegistryHive.LocalMachine;
                    case 3:
                        return RegistryHive.Users;
                    case 4:
                        return RegistryHive.CurrentConfig;
                    case 5:
                        return RegistryHive.PerformanceData;

                    //TODO: MIGRATION: Core API does not contain this value
#if NETFRAMEWORK
                    case 6:
                        return RegistryHive.DynData;
#endif

                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
    #endregion

    #region ToLowerConverter
    /// <summary>
    /// Converts string values to lower string values.
    /// </summary>
    public class ToLowerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? value : value.ToString().ToLower();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ToUpperConverter
    /// <summary>
    /// Converts string values to upper string values.
    /// </summary>
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.ToString().ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region CurrencyToStringConverter
    /// <summary>
    /// Converts a currency string to a formated currency string.
    /// </summary>
    public class CurrencyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;

            if (double.TryParse(value.ToString(), out double currencyValue))
            {
                CultureInfo info = System.Threading.Thread.CurrentThread.CurrentCulture;
                return String.Format("{0:C}", currencyValue);
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region NumberToRoundedConverter
    /// <summary>
    /// Converts an double value to a rounded double value.
    /// </summary>
    public class NumberToRoundedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double n;
            if (double.TryParse(value.ToString(), out n))
            {
                return Math.Round(n, 1);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion        

    #region IOPathConverter
    /// <summary>
    /// Converts a full path to file to a file name.
    /// </summary>
    public class IOPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null & (value is String))
                {
                    if (!String.IsNullOrWhiteSpace(value.ToString()))
                    {
                        return Path.GetFileName(value.ToString());
                    }
                }
            }
            catch
            {
                return value;
            }
            return parameter;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region SplitStringConverter
    public class SplitStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in (value as ObservableCollection<string>))
                {
                    builder.Append(s);
                    builder.Append(";");
                }
                return builder.ToString();
            }
            catch
            {
                return string.Empty;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                ObservableCollection<string> strings = new ObservableCollection<string>();

                foreach (string s in (value as string).Split(new char[] { ';' }))
                {

                    if (s.Trim() != string.Empty)
                    {
                        strings.Add(s);
                    }

                }
                return strings;
            }
            catch
            {
                return new ObservableCollection<string>();
            }
        }

        #endregion
    }
    #endregion

    #region TypeToStringConverter
    public class TypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value.GetType().ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ExtensionConverter
    public class ExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is IcyFileSystemInfo)
                {
                    IcyFileSystemInfo info = (IcyFileSystemInfo)value;
                    if (info.IsDirectory)
                    {
                        return "Directory";
                    }
                    else
                    {
                        return Path.GetExtension(info.FullName);
                    }
                }
                else if (value is IcyDriveInfo)
                {
                    return "Drive";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ReverseValueConverter
    public class ReverseValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue & values[1] != DependencyProperty.UnsetValue)
            {
                int initialTotal = (int)values[0];
                int totalLeft = (int)values[1];
                int val = Math.Abs(totalLeft - initialTotal);
                return (double)val;
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region OperatingSystemConverter
    public class OperatingSystemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OperatingSystems os = (OperatingSystems)value;
            switch (os)
            {
                case OperatingSystems.WindowsXp:
                    return "Microsoft Windows XP";
                case OperatingSystems.Windows2000:
                    return "Microsoft Windows 2000";
                case OperatingSystems.Windows7:
                    return "Microsoft Windows 7";
                case OperatingSystems.Windows8:
                    return "Microsoft Windows 8";
                case OperatingSystems.Windows81:
                    return "Microsoft Windows 8.1";
                case OperatingSystems.Windows10:
                    return "Microsoft Windows 10";
                case OperatingSystems.WindowsServer2003:
                    return "Microsoft Windows Server 2003";
                case OperatingSystems.WindowsServer2003R2:
                    return "Microsoft Windows Server 2003 R2";
                case OperatingSystems.WindowsServer2008:
                    return "Microsoft Windows Server 2008";
                case OperatingSystems.WindowsServer2008R2:
                    return "Microsoft Windows Server 2008 R2";
                case OperatingSystems.WindowsServer2012:
                    return "Microsoft Windows Server 2012";
                case OperatingSystems.WindowsVista:
                    return "Microsoft Windows Vista";
                default:
                    return "Unknown Operating System";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion    

    #region DefaultButtonConverter
    public class DefaultButtonConverter : BindableParametersConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.BindableConverterParameter != null && this.BindableConverterParameter is IMessageBoxModel && value is NotificationButtons)
            {
                NotificationButtons valueEnum = (NotificationButtons)value;
                IMessageBoxModel parameterEnum = (IMessageBoxModel)this.BindableConverterParameter;
                return valueEnum == parameterEnum.DefaultButton;
            }
            return false;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion  

    #region HTMLToXAMLConverter
    public class HTMLToFlowDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(value as string))
                {
                    var doc = HTMLConverter.HtmlToXamlConverter.ConvertHtmlToXaml(value as string, true);
                    FlowDocument document = (FlowDocument)XamlReader.Parse(doc);
                    return document;
                }
            }
            catch
            {
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region MetaDataIconConverter
    public class MetaDataIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var metaData = value as IPluginMetadata;
            if (metaData != null && metaData.HasIconResource)
            {
                string[] iconSplit = metaData.IconResource.Split(';');
                if (iconSplit.Length >= 2)
                {
                    Assembly assembly = Assembly.Load(iconSplit[0]);
                    if (assembly != null)
                    {
                        string resourceKey = iconSplit[1];
                        //try to resolve from embeded resources
                        var stream = assembly.GetManifestResourceStream(resourceKey);
                        if (stream != null)
                        {
                            var image = new BitmapImage();
                            image.BeginInit();
                            image.StreamSource = stream;
                            image.EndInit();
                            return image;
                        }
                    }
                }
                else
                {
                    //try to resolve from application resources
                    if (Application.Current != null)
                        return Application.Current.TryFindResource(metaData.IconResource);
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region NullImageSourceConverter
    public class NullImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value is string stringValue && stringValue.Length == 0)
                return DependencyProperty.UnsetValue;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    #endregion

    #region ImageSourceResourceConverter
    public class ImageSourceResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceString = value as string;

            if (!string.IsNullOrWhiteSpace(resourceString))
            {
                object foundResource = null;

                //try to resolve from application resources
                if (Application.Current != null)
                    foundResource = Application.Current.TryFindResource(resourceString);

                //return found resource
                if (foundResource != null)
                    return foundResource;
            }

            //return null image source
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Hidden;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class NotNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return Visibility.Hidden;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}


