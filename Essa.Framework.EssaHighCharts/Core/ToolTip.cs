using System;
using Essa.Framework.UtilCore.Extensions;
using Highcharts.Core.Appearance;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class ToolTip
    {

        public ToolTip()
        { }
        public ToolTip(string format)
        {
            formatter = format;
        }

        [JsonProperty]
        public string backgroundColor { get; set; }
        [JsonProperty]
        public string borderColor { get; set; }
        [JsonProperty]
        public int? borderRadius { get; set; }
        [JsonProperty]
        public int? borderWidth { get; set; }
        [JsonProperty]
        public bool? crosshairs { get; set; }
        [JsonProperty]
        public bool? enabled { get; set; }

        [JsonProperty]
        public string formatter
        {
            get
            {
                if (string.IsNullOrEmpty(_formatter))
                    return null;
                else
                    return String.Format("function(event){{ var tmp = {0}; if(typeof(tmp) == 'function'){{return tmp(this);}}else{{ return tmp;}} }}", _formatter);
            }
            set { _formatter = value; }
        }
        private string _formatter { get; set; }

        [JsonProperty]
        public bool? shadow { get; set; }
        [JsonProperty]
        public bool? shared { get; set; }
        [JsonProperty]
        public int? snap { get; set; }
        [JsonProperty]
        public CSSObject style { get; set; }

        public override string ToString()
        {
            string _tmp = this.ToJson(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return string.Format("tooltip: {0} ,", _tmp);


        }

    }

}
