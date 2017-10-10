using System;
using System.Globalization;
using System.Windows;

namespace WPFStyle
{
    public class ThicknessMultiConverter : BaseValueConverter<ThicknessMultiConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new Thickness(0, 0, 0, 0);

            if(parameter != null)
            {
                return new Thickness(-(System.Convert.ToDouble(value)), 0, 0, 0);
            }
            return new Thickness(System.Convert.ToDouble(value), 0, 0, 0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
