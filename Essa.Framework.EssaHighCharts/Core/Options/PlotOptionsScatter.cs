using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core.PlotOptions
{

    [Serializable]
    public class PlotOptionsScatter : PlotOptionsSeries
    {
        
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
