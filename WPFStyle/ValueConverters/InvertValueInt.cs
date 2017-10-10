using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFStyle
{
    /// <summary>
    /// Apenas inverte o valor de positivo para negativo
    /// </summary>
    public class InvertValueInt : BaseValueConverter<InvertValueInt>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            if (value is int)
            {
                return -((int)value);
            }
            else if (value is double)
            {
                return -((double)value);
            }
            else
                return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
