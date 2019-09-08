using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Highcharts.Core.Appearance;
using Highcharts.Core.PlotOptions;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public abstract class Axis
    {
        public bool? allowDecimals { get; set; }
        public string alternateGridColor { get; set; }
        public DateTimeLabelFormats dateTimeLabelFormats { get; set; }
        public bool? endOnTick { get; set; }
        public string gridLineColor { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DashStyle? gridLineDashStyle { get; set; }
        public int? gridLineWidth { get; set; }
        public string id { get; set; }
        public Labels labels { get; set; }
        public string lineColor { get; set; }
        public int? lineWidth { get; set; }
        public int? linkedTo { get; set; }
        public int? max { get; set; }
        public double? maxPadding { get; set; }
        public int? maxZoom { get; set; }
        public int? min { get; set; }
        public string minorGridLineColor { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DashStyle? minorGridLineDashStyle { get; set; }
        public int? minorGridLineWidth { get; set; }
        public string minorTickColor { get; set; }
        public int? minorTickInterval { get; set; }
        public int? minorTickLength { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TickPosition? minorTickPosition {get; set; }
        public int? minorTickWidth { get; set; }
        public double? minPadding { get; set; }
        public int? offset { get; set; }
        public bool? opposite { get; set; }
        public PlotBands plotBands { get; set; }
        public PlotLines plotLines { get; set; }
        public bool? reversed { get; set; }
        public bool? showFirstLabel { get; set; }
        public bool? showLastLabel { get; set; }
        public DataLabels stackLabels { get; set; }
        public int? startOfWeek { get; set; }
        public bool? startOnTick { get; set; }
        public string tickColor { get; set; }
        public long? tickInterval { get; set; }
        public int? tickLength { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TickPlacement? tickmarkPlacement { get; set; }
        public int? tickPixelInterval { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TickPosition? tickPosition { get; set; }
        public int? tickWidth;
        public Title title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AxisDataType? type { get; set; }

        public Axis()
        {
            title = new Title(string.Empty);
        }

        internal void ApplyTheme(CSSObject themeConfiguration)
        {
            title.ApplyTheme(themeConfiguration);
        }

    }

}
