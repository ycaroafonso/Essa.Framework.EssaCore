using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class XAxisItem : Axis
    {
        public XAxisItem()
        {

        }

        public object[] categories;

        public override string ToString()
        {
            string ignored = "";
            ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return ignored;
        }
      
    }
}
