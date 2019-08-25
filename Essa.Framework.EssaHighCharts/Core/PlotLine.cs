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
    public class PlotLine
    {
        public string color { get; set; }
        public DashStyle? dashStyle { get; set; }
        public Events.PlotEvents events { get; set; }
        public string id { get; set; }
        public PlotLabel label { get; set; }
        public double? value { get; set; }
        public int? width { get; set; }
        public int? zIndex { get; set; }

        public PlotLine()
        {
           
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return ignored;
        }
    }

}
