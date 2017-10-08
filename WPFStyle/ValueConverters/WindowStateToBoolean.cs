using System;
using System.Globalization;
using System.Windows;

namespace WPFStyle
{
    /// <summary>
    /// Converte <see cref="bool"/> para uma string especifica
    /// </summary>
    public class WindowStateToBoolean : BaseValueConverter<WindowStateToBoolean>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (WindowState)value == WindowState.Maximized ? true : false;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
