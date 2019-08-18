using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Highcharts.Core.Appearance;

namespace Highcharts.Core
{

    [Serializable]
    public class PlotBand
    {
        public string color { get; set; }
        public Events.PlotEvents events { get; set; }
        public double? from { get; set; }
        public string id { get; set; }
        public PlotLabel label { get; set; }
        public double? to { get; set; }
        public int? zIndex { get; set; }

        public PlotBand()
        {
           
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return ignored;
        }
    }

}
