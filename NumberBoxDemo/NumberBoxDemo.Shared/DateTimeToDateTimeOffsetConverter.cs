using System;
using Windows.UI.Xaml.Data;

namespace kahua.host.uno.ui.converters
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime date)
            {
                return new DateTimeOffset(date);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTimeOffset dto)
            {
                return dto.DateTime;
            }
            return null;
        }
    }
}