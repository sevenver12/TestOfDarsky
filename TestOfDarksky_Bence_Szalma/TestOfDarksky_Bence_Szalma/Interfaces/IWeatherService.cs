using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Model;
namespace TestOfDarksky_Bence_Szalma.Interfaces
{
    public interface IWeatherService : IDataService<CityInfo>
    {
        City TrackedCity { get; set; }
        string CopyRightInfo { get; }
    }
}
