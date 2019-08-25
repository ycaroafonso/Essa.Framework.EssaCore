using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class YAxis : List<YAxisItem>
    {
        public YAxis()
        {

        }

        public override string ToString()
        {
            string ignored = "";
            var keys = new List<string>();

            foreach (YAxisItem axis in this)
            {
                ignored = JsonConvert.SerializeObject(axis, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                keys.Add(ignored);

            }
            var serialize = string.Join(",", keys.ToArray());
            return string.Format("yAxis: [{0}],", serialize);
            //return string.Format("yAxis: [{0}],", ignored);
        }
      
    }
}
