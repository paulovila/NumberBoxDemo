using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace kahua.host.uno.ui.converters
{
    public class ByteCountToKilobyteStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            long ret;
            Type valueType = value.GetType();
            if (valueType == typeof(string))
            {
                bool success = long.TryParse((string)value, out ret);
                if (success)
                {
                    value = ret;
                    valueType = value.GetType();
                }
            }

            if (valueType != typeof(int) && valueType != typeof(long))
            {
                return DependencyProperty.UnsetValue;
            }

            var sizeInBytes = (long)value;

            return $"{sizeInBytes}B";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return int.Parse(((string)value).Replace("B", ""));
        }
    }
}
