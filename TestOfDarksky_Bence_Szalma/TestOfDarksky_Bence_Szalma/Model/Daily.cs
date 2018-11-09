using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOfDarksky_Bence_Szalma.Model
{
    public partial class Daily
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }
}
