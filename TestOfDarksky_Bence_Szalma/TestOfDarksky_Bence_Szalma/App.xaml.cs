using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace TestOfDarksky_Bence_Szalma
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.IncludeInvariantCulture = false;
            LocalizeDictionary.Instance.Culture = new CultureInfo(TestOfDarksky_Bence_Szalma.Properties.Settings.Default.Culture);
        }
    }
}
