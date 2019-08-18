using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class MarkerStateSettings
    {
        public MarkerStateSettings()
        {  }
        
        [JsonProperty]
        public bool? enabled { get; set; }
        [JsonProperty]
        public string fillColor { get; set; }
        [JsonProperty]
        public string lineColor { get; set; }
        [JsonProperty]
        public int? lineWidth { get; set; }
        [JsonProperty]
        public int? radius { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
        }
    }
}
