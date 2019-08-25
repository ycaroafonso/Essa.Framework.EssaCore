using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class SerieStates
    {
        public SerieStates()
        { }
        
        public SerieStateSettings hover;
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
