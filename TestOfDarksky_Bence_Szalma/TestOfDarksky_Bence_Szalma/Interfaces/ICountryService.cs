using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Model;

namespace TestOfDarksky_Bence_Szalma.Interfaces
{
    public interface ICountryService : IDataService<City>
    {
        ObservableCollection<City> ShortCountries(ICollection<City> list, Predicate<City> predicate);

    }
}
