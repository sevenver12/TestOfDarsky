using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TestOfDarksky_Bence_Szalma.Helper;
using TestOfDarksky_Bence_Szalma.Interfaces;
using TestOfDarksky_Bence_Szalma.Model;
using TestOfDarksky_Bence_Szalma.Services;
using TestOfDarksky_Bence_Szalma.View;

namespace TestOfDarksky_Bence_Szalma.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel(Frame mainframe)
        {
            StateClosed = true;
            _countryService = new DumyCountryService();
            _mainFrame = mainframe;
            ToWellcomePage();
        }

        private void ToWellcomePage()
        {
            _mainFrame.Navigate(new WellcomePage());

        }

        public async void Initialize()
        {
            DetailsViewModel = new DetailsViewModel(new DarkSkyWeatherService());
            Cities = new ObservableCollection<City>(await _countryService.GetData());
        }
        public DetailsViewModel DetailsViewModel { get; set; }
        private ICountryService _countryService;
        private Frame _mainFrame;

        public ObservableCollection<City> Cities { get; set; }

        private ICommand _citySelected;

        public ICommand CitySelectedCommand
        {
            get { return _citySelected = _citySelected ?? new RelayCommand<City>(async c => await LoadCity(c)); }

        }

        private async Task LoadCity(City city)
        {
            await DetailsViewModel.GetData(city);
            _mainFrame.Navigate(new DetailsPage(DetailsViewModel));
        }

        private ICommand _openHamburger;

        public ICommand OpenHamburgerCommand
        {
            get { return _openHamburger = _openHamburger ?? new RelayCommand(HamburgerOpen); }
        }
        //private bool StateClosed = true;
        private void HamburgerOpen()
        {
            StateClosed = !StateClosed;
        }
        private bool _stateClosed;

        public bool StateClosed
        {
            get { return _stateClosed; }
            set { Set(ref _stateClosed, value); }
        }

        private ICommand _wellcomeCommand;

        public ICommand WellcomeCommand
        {
            get { return _wellcomeCommand = _wellcomeCommand ?? new RelayCommand(ToWellcomePage) ; }
        }


    }
}
