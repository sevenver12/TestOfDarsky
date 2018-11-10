using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestOfDarksky_Bence_Szalma.Converters
{
    public class DateTimeFromTicksConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (long.TryParse(value.ToString(),out long ticks))
            {
                var dt = new DateTime(ticks);
                return dt.ToString("MM/dd");
            }
            return Helper.LocalizationHelper.GetLocalizedValue<string>("Error");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
