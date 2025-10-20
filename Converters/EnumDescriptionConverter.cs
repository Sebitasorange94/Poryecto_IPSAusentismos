using System;
using System.Globalization;
using System.Windows.Data;

namespace IpsAusentismos.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString() ?? string.Empty;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value ?? string.Empty;
    }
}
