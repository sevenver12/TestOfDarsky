using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Interfaces;
using TestOfDarksky_Bence_Szalma.Model;

namespace TestOfDarksky_Bence_Szalma.Services
{
    public class DumyCountryService : ICountryService
    {
        public Task<IEnumerable<City>> GetData()
        {
            Country hun = new Country() { FName = "Hungary" };
            Country lux = new Country() { FName = "Luxemburg" };
            Country aust = new Country() { FName = "Ausztria" };
            Country cz = new Country() { FName = "Czech" };
            Country ger = new Country() { FName = "Germany" };
            Country neth = new Country() { FName = "Netherlands" };



             var result = new List<City>
            {
                new City
                {
                    FName = "Luxembourg",
                    Country = lux,
                    Lat = 49.6116,
                    Lon = 6.1319

                },
                new City
                {
                    FName = "Budapest",
                    Country = hun,
                    Lat = 47.4979,
                    Lon = 19.0402
                },
                new City
                {
                    FName = "Debrecen",
                    Country = hun,
                    Lat = 47.531605,
                    Lon = 21.627312,

                },
                new City
                {
                    FName = "Pécs",
                    Country = hun,
                    Lat = 46.072735,
                    Lon = 18.232266
                },
                new City
                {
                    FName = "Wienna",
                    Country = aust,
                    Lat = 48.208174,
                    Lon = 16.373819,
                },
                new City
                {
                    FName = "Prague",
                    Country = cz,
                    Lat = 50.075538,
                    Lon = 14.437800,

                },
                new City
                {
                    FName = "München",
                    Country = ger,
                    Lat = 48.135125,
                    Lon = 11.581981,
                },
                new City
                {
                    FName = "Amsterdam",
                    Country = neth,
                    Lat = 52.370216,
                    Lon = 4.895168,
                },
            };
            return Task.FromResult(result as IEnumerable<City>);
        }

        public ObservableCollection<City> ShortCountries(ICollection<City> list, Predicate<City> predicate)
        {
            return new ObservableCollection<City>(list.Where(w => predicate(w)));
        }
    }
}
