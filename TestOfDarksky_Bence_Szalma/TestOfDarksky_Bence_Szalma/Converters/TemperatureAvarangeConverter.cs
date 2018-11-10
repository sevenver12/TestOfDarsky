using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestOfDarksky_Bence_Szalma.Converters
{
    public class TemperatureAvarangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (double.TryParse(values[0].ToString(), out double data1) && double.TryParse(values[1].ToString(), out double data2))
                {
                    return ((data1 + data2) / 2).ToString();
                }
            }
            catch (Exception)
            {
            }
            return Helper.LocalizationHelper.GetLocalizedValue<string>("Error");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
