using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Highcharts.Core.PlotOptions
{
    [Serializable]
    public abstract class PlotOptionsSeries
    {
        public bool? allowPointSelect { get; set; }
        public bool? animation { get; set; }
        public string color { get; set; }
        public bool? connectNulls { get; set; }
        public string cursor { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DashStyle? dashStyle { get; set; }
        
        public DataLabels dataLabels { get; set; }
        public bool? enableMouseTracking { get; set; }
        public Events.PlotOptionEvents events { get; set; }
        public string id { get; set; }
        public int? lineWidth { get; set; }
        public Marker marker { get; set; }
        public Events.PlotPointEvents point { get; set; }
        public int? pointStart { get; set; }
        public int? pointInterval { get; set; }
        public bool? shadow { get; set; }
        public bool? showInLegend { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Stacking? stacking { get; set; }

        public SerieStates states { get; set; }
        public bool? stickyTracking { get; set; }
        public bool? visible { get; set; }
        public int? zIndex { get; set; }
        
    }
}
