using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace kahua.host.uno.ui.converters
{
    public class EnumToLocalizedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            return $"{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
