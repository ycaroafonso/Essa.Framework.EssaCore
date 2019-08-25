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
    [JsonObject(MemberSerialization.OptOut)]
    public class Labels
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Align? align { get; set; }
        public bool enabled { get; set; }
        public int? rotation { get; set; }
        public CSSObject style { get; set; }

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
        [JsonIgnore]
        private string _formatter { get; set; }


        public int? staggerLines  { get; set; }
        public int? step { get; set; }

        public int? x { get; set; }
        public int? y { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public VerticalAlign? verticalAlign { get; set; }

        public Labels()
        {
            enabled = true;
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //return string.Format("legend: {0},", ignored);
            return ignored;
        }
    }

}
