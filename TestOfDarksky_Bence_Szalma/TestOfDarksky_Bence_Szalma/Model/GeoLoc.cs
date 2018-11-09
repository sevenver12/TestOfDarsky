using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Helper;

namespace TestOfDarksky_Bence_Szalma.Model
{
    public abstract class GeoLoc  : ObservableObject
    {
        public string FName { get; set; }
        public string SName
        {
            get
            {
                if (FName.Count() > 3)
                {
                    return FName.Take(3).ToString();
                }
                else
                {
                    return FName;
                }
            }
        }
    }
}
