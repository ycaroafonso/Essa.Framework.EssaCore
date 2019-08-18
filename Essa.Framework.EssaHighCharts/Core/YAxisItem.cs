using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class YAxisItem : Axis
    {
        public YAxisItem()
        {

        }

        public override string ToString()
        {
            string ignored = "";
            ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return ignored;
        }
      
    }
}
