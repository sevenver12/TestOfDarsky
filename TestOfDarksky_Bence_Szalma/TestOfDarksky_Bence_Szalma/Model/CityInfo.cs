using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Helper;
namespace TestOfDarksky_Bence_Szalma.Model
{
    public class CityInfo : ObservableObject
    {
        private decimal _temperature;

        public decimal Temperature
        {
            get { return _temperature; }
            set { Set(ref _temperature, value); }
        }
        private decimal _apparentTemperature;

        public decimal ApparentTemperature
        {
            get { return _apparentTemperature; }
            set { Set(ref _apparentTemperature, value); }
        }
        private decimal _pressure;

        public decimal Pressure
        {
            get { return _pressure; }
            set { Set(ref _pressure, value); }
        }
        private decimal _windSpeed;

        public decimal WindSpeed
        {
            get { return _windSpeed; }
            set { Set(ref _windSpeed, value); }
        }
        private decimal humidity;

        public decimal Humidity
        {
            get { return humidity; }
            set { Set(ref humidity, value); }
        }

        private decimal uvIndex;

        public decimal UvIndex
        {
            get { return uvIndex; }
            set { Set(ref uvIndex, value); }
        }



    }
}
