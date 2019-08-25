using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core.PlotOptions
{

    [Serializable]
    public class PlotOptionsArea : PlotOptionsSeries
    {
        public string fillColor { get; set; }
        public double? fillOpacity { get; set; }
        public string lineColor { get; set; }
        public int? threshold { get; set; }
        
        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            if (!string.IsNullOrEmpty(ignored))
            {
                return string.Format("plotOptions: {{ series: {0} }},", ignored);
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
