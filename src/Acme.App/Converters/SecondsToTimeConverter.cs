using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace Acme.App.Converters
{
    public class SecondsToTimeConverter : IValueConverter
    {
        public string Format { get; set; } = @"hh\:mm\:ss";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int seconds)
            {
                var timeSpan = TimeSpan.FromSeconds(seconds);
                return timeSpan.ToString(Format);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
