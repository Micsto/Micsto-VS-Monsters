using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MicstoVsMonsters.Common.Converters
{
    public sealed class BoolToInvisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo ci)
        {
            return ((value is bool && (bool)value) ^ parameter != null) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo ci)
        {
            return (value is Visibility && (Visibility)value == Visibility.Collapsed) ^ parameter != null;
        }
    }
}
