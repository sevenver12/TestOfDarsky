using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Extensions;

namespace TestOfDarksky_Bence_Szalma.Helper
{


    public static class LocalizationHelper
    {
        public static T GetLocalizedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>(Assembly.GetCallingAssembly().GetName().Name + ":Strings:" + key);
        }
    }
}
