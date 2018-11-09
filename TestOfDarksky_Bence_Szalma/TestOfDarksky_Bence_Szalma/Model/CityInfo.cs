using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOfDarksky_Bence_Szalma.Helper;
namespace TestOfDarksky_Bence_Szalma.Model
{

    public partial class CityInfo
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("currently")]
        public Currently Currently { get; set; }

        [JsonProperty("daily")]
        public Daily Daily { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}
