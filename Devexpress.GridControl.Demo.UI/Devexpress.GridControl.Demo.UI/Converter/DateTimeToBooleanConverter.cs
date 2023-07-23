using System;
using System.Windows.Data;

namespace Devexpress.GridControl.Demo.UI.Converter
{
    class DateTimeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime res;
            if (DateTime.TryParse(value.ToString(), out res))
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
