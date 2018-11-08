using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TestOfDarksky_Bence_Szalma.Helper;

namespace TestOfDarksky_Bence_Szalma.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            StateClosed = true;
            StateOpen = false;
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
            StateOpen = !StateOpen;
        }
        private bool _stateClosed;

        public bool StateClosed
        {
            get { return _stateClosed; }
            set { Set(ref _stateClosed, value); }
        }

        private bool _stateOpen;

        public bool StateOpen
        {
            get { return _stateOpen; }
            set { Set(ref _stateOpen, value); }
        }

    }
}
