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
            using (HttpClient client = new HttpClient())
            {
                return new List<CityInfo> { await GetCityInfo(client) };
            }
        }

        private async Task<CityInfo> GetCityInfo(HttpClient client)
        {
            var lang = TestOfDarksky_Bence_Szalma.Properties.Settings.Default.Culture;
            var req = new Uri($"https://api.darksky.net/forecast/{_apiSecret}/{TrackedCity.Lat},{TrackedCity.Lon}?lang={lang}&exclude=flags,minutely,hourly");
            var cont = await client.GetAsync(req);
            if (cont.IsSuccessStatusCode)
            {
                var stringResponse = await cont.Content.ReadAsStringAsync();
                return await Json.ToObjectAsync<CityInfo>(stringResponse);
            }
            return null;

        }
    }
}
