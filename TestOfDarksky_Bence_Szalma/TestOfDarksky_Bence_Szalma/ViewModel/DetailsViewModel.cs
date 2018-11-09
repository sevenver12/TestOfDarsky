using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Helper;
using TestOfDarksky_Bence_Szalma.Interfaces;
using TestOfDarksky_Bence_Szalma.Model;

namespace TestOfDarksky_Bence_Szalma.ViewModel
{
    public class DetailsViewModel : ObservableObject
    {
        private IWeatherService _weatherService;
        public DetailsViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }
        internal async Task GetData(City city)
        {
            _weatherService.TrackedCity = city;
            var result = await _weatherService.GetData();
            CityInfo = result.FirstOrDefault(); ;
        }
        private CityInfo _cityInfo;

        public string CoppyRight { get => _weatherService.CopyRightInfo; }

        public CityInfo CityInfo
        {
            get { return _cityInfo; }
            set { Set(ref _cityInfo, value); }
        }

    }
}
