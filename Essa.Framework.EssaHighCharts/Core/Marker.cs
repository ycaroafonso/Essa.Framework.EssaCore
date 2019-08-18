using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class Marker : MarkerStateSettings
    {
        public Marker()
        { }
        public Marker(string symbol)
        {
            this.symbol = symbol;
        }

        public MarkerStates states;
        public string symbol;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
