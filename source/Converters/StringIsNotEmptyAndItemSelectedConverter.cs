using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace tfm.Converters
{
    public class StringIsNotEmptyAndItemSelectedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var text = values[0] as string;
            var isSelected = values[1] as bool?;
            return isSelected == false || (!string.IsNullOrEmpty(text) && isSelected == true);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
