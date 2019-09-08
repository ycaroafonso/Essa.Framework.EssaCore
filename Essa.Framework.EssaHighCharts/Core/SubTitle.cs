using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    public class SubTitle : Title
    {
        public SubTitle(string subTitleText) : base(subTitleText)
        {

        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(text))
            {
                string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                return string.Format("subtitle: {0},", ignored);
            }
            else
                return string.Empty;
        }
    }
}
