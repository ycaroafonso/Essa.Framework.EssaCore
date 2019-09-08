using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SerieStateSettings
    {
        public SerieStateSettings()
        {  }
        
        [JsonProperty]
        public bool? enabled { get; set; }
        [JsonProperty]
        public int? lineWidth { get; set; }
        [JsonProperty]
        public Marker marker { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
        }
    }
}
