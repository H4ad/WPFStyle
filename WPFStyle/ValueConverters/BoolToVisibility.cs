using System;
using System.Globalization;
using System.Windows;

namespace WPFStyle
{
    /// <summary>
    /// Converte bool para visibility
    /// </summary>
    public class BoolToVisibility : BaseValueConverter<BoolToVisibility>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
