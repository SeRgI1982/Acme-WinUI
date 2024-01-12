using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Acme.App.Wpf.Converters
{
    public class SecondsToTimeConverter : IValueConverter
    {
        public string Format { get; set; } = @"hh\:mm\:ss";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int seconds)
            {
                var timeSpan = TimeSpan.FromSeconds(seconds);
                return timeSpan.ToString(Format);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
