using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Highcharts.Core.Data.Chart
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class Serie
    {

        public string name;
        public string id;
        [JsonConverter(typeof(StringEnumConverter))]
        public RenderType? type;
        public int? level { get; set; } 
        public string color { get; set; }
        public bool? showInLegend { get; set; }
        public bool? selected  { get; set; }
        public bool? visible { get; set; }
        public object[] center;
        public int? size;
        // Added stacking, but it isn't valid for all serie types. Should it be here?
        public Stacking? stack;
        public int? innerSize;
        public int? xAxis;
        public int? yAxis;

        public int? y{ get; set; }

        public object[] data;

        public override string ToString()
        {
            if (center.Length < 2)
                center = null;
            else if (center.Length > 2)
                center = new object[] { center.GetValue(0), center.GetValue(1) };

            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
        }
    }
}
