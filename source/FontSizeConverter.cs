using System;
using System.Globalization;
using System.Windows.Data;

namespace tfm
{
    public class FontSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double width && values[1] is double height)
            {
                // Set your base window dimensions and base font size here
                const double baseWindowWidth = 450;
                const double baseWindowHeight = 450;
                const double baseFontSize = 14;

                // Calculate the scaling factor
                double scaleFactor = Math.Min(width / baseWindowWidth, height / baseWindowHeight);

                // Calculate the new font size
                return baseFontSize * scaleFactor;
            }

            return 12; // Default font size
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
