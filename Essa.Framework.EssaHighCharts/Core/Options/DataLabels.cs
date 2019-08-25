using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Highcharts.Core.Appearance;

namespace Highcharts.Core.PlotOptions
{

    [Serializable]
    public class DataLabels : Labels
    {
        public string color { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public VerticalAlign? verticalAlign { get; set; }

        public DataLabels()
        {
            enabled = true;
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return ignored;
        }
    }

}
