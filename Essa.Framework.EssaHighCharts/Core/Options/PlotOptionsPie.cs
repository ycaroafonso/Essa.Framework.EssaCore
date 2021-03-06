﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core.PlotOptions
{

    [Serializable]
    public class PlotOptionsPie : PlotOptionsSeries
    {

        public string borderColor  { get; set; }
        public int? borderWidth  { get; set; }
        public object innserSize { get; set; }
        public int? size { get; set; }
        public int? sliceOffset { get; set; }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            if (!string.IsNullOrEmpty(ignored))
            {
                return string.Format("plotOptions: {{ pie: {0} }},", ignored);
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
