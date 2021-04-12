using System;
using Xamarin.Forms;

namespace TodoApp.Converter
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (bool)value;

            return val == true ? "Completed" : "Not Completed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
