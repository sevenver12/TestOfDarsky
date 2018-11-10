using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ///Must, if there will be new languages implemented
            Units = new ObservableCollection<MeasurementUnit>()
            {
                new MeasurementUnit{Key = "si", Value =  LocalizationHelper.GetLocalizedValue<string>("si") },
                new MeasurementUnit{Key = "us", Value = LocalizationHelper.GetLocalizedValue<string>("us") },
            };
            _selectedUnit = Units.FirstOrDefault(fod => fod.Key == Properties.Settings.Default.Unit) ?? Units.First();

        }
        internal async Task GetData(City city)
        {
            _weatherService.TrackedCity = city;
            var result = await _weatherService.GetData();
            CityInfo = result.FirstOrDefault();
        }
        private CityInfo _cityInfo;

        public ObservableCollection<MeasurementUnit> Units { get; set; }

        private MeasurementUnit _selectedUnit;

        public MeasurementUnit SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                Set(ref _selectedUnit, value,ChangeUnits);
            }
        }
        
        private async void ChangeUnits()
        {
            Properties.Settings.Default.Unit = SelectedUnit.Key;
            Properties.Settings.Default.Save();
            await GetData(_weatherService.TrackedCity);
        }


        public string CoppyRight { get => _weatherService.CopyRightInfo; }

        public CityInfo CityInfo
        {
            get { return _cityInfo; }
            set { Set(ref _cityInfo, value); }
        }

    }
}
