using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class Background
    {

        public int[] linearGradient { get; set; }        
        public Collection<object[]> stops { get; set; }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return string.Format("{0},", ignored);           
        }
        
    }
}
