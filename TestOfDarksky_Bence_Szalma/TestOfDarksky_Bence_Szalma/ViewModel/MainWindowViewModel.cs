using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TestOfDarksky_Bence_Szalma.Helper;
using TestOfDarksky_Bence_Szalma.Interfaces;
using TestOfDarksky_Bence_Szalma.Model;
using TestOfDarksky_Bence_Szalma.Services;

namespace TestOfDarksky_Bence_Szalma.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            StateClosed = true;
            _countryService = new DumyCountryService();
        }

        public async void Initialize()
        {
            Cities = new ObservableCollection<City>(await _countryService.GetData());

        }
        private ICountryService _countryService;
        public ObservableCollection<City> Cities { get; set; }


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


    }
}
