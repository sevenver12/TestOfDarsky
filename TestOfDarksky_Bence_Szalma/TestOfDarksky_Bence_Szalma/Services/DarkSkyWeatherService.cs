using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Interfaces;
using TestOfDarksky_Bence_Szalma.Model;
using TestOfDarksky_Bence_Szalma.Helper;
using System.Configuration;
using System.Globalization;

namespace TestOfDarksky_Bence_Szalma.Services
{
    public class DarkSkyWeatherService : IWeatherService
    {
        private string _apiSecret = AppSettingsHelper.ReadSetting("WeatherApiKey");
        public City TrackedCity { get; set; }
        public string CopyRightInfo { get => "Powered by Dark Sky"; }

        /// <summary>
        /// if later on, there will be an update, so the use may get the CityInfo of a whole country, this should remain Ienumerable
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CityInfo>> GetData()
        {
            if (TrackedCity == null) return null;
            var lang = TestOfDarksky_Bence_Szalma.Properties.Settings.Default.Culture;
            var units = TestOfDarksky_Bence_Szalma.Properties.Settings.Default.Unit;
            using (HttpClient client = new HttpClient())
            {
                return new List<CityInfo> { await GetCityInfo(client, lang,units) };
            }
        }

        private async Task<CityInfo> GetCityInfo(HttpClient client,string lang, string units)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            var req = new Uri($"https://api.darksky.net/forecast/{_apiSecret}/{TrackedCity.Lat.ToString("N", nfi)},{TrackedCity.Lon.ToString("N",nfi)}?lang={lang}&exclude=flags,minutely,hourly&units={units}");
            var cont = await client.GetAsync(req);
            if (cont.IsSuccessStatusCode)
            {
                var stringResponse = await cont.Content.ReadAsStringAsync();
                var info= await Json.ToObjectAsync<CityInfo>(stringResponse);
                var dt = DateTime.Today;
                foreach (var data in info.Daily.Data)
                {
                    data.Time = dt.Ticks;
                   dt = dt.AddDays(1);
                }
                return info;
            }
            return null;

        }
    }
}
