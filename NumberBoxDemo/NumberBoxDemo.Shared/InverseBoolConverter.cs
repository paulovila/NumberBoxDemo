using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace kahua.host.uno.ui.converters
{
    public class InverseBoolConverter : IValueConverter
    {
        #region Instance Properties

        public static InverseBoolConverter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InverseBoolConverter();
                }
                return _instance;
            }
        }
        private static InverseBoolConverter _instance = null;

        #endregion Instance Properties

        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return !(bool)value;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return !(bool)value;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}