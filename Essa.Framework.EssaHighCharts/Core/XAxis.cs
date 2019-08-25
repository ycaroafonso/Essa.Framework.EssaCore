using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class XAxis : List<XAxisItem>
    {
        public XAxis()
        {

        }

        public override string ToString()
        {
            string ignored = "";
            var keys = new List<string>();

            foreach (XAxisItem axis in this)
            {
                ignored = JsonConvert.SerializeObject(axis, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                keys.Add(ignored);

            }
            var serialize = string.Join(",", keys.ToArray());
            return string.Format("xAxis: [{0}],", serialize);
            //return string.Format("xAxis: [{0}],", ignored);
        }
    }
}
