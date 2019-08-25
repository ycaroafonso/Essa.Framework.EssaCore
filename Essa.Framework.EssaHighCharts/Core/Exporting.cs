using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class Exporting
    {
        public bool? enabled { get; set; }

        public Exporting()
        {
            enabled = false;
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return string.Format("exporting: {0},", ignored);
        }

    }
}
