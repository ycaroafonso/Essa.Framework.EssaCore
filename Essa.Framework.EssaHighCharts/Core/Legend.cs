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
    public class Legend
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Align? align { get; set; }

        public string backgroundColor { get; set; }
        public string borderColor { get; set; }

        public int? borderRadius { get; set; }
        public int? borderWidth { get; set; }

        public bool? enabled { get; set; }
        public bool? floating { get; set; }
        public ItemStyle itemHiddenStyle { get; set; }
        public ItemStyle itemHoverStyle { get; set; }
        public ItemStyle itemStyle { get; set; }
        public int? itemWidth { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Layout? layout { get; set; }

        public string labelFormatter
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
        private string _formatter;

        public int? lineHeight { get; set; }
        public int? margin { get; set; }
        public bool? reversed { get; set; }
        public bool? shadow { get; set; }
        public CSSObject style { get; set; }
        public int? symbolPadding { get; set; }
        public int? symbolWidth { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VerticalAlign? verticalAlign { get; set; }
        public int? width { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        
        

        public Legend()
        {
            enabled = true;
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return string.Format("legend: {0},", ignored);
        }

        internal void ApplyTheme(LegendStyle themeConfiguration)
        {   
            itemHiddenStyle.CopyStyles(themeConfiguration.hiddenStyle);
            itemHoverStyle.CopyStyles(themeConfiguration.hoverStyle);
            itemStyle.CopyStyles(themeConfiguration.style);
        }

    }

}
