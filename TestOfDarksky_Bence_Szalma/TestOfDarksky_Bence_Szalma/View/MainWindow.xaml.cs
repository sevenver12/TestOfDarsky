using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestOfDarksky_Bence_Szalma.ViewModel;

namespace TestOfDarksky_Bence_Szalma.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new MainWindowViewModel(mainFrame);
            ViewModel.Initialize();
        }

        public MainWindowViewModel ViewModel { get; }

        private void LangBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.Culture = e.AddedItems[0].ToString();
            Properties.Settings.Default.Save();
        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CitiesLv.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Country.SName");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
