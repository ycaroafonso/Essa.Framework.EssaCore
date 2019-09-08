using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core.Appearance
{
    [Serializable]
    public class ColorSet
    {
        
        /// <summary>
        /// When all colors are used, new colors are pulled from the start again. Defaults to:
        /// colors: ['#4572A7', '#AA4643', '#89A54E', '#80699B', '#3D96AE', '#DB843D', '#92A8CD', '#A47D7C', '#B5CA92']    
        /// </summary>
        public string[] colors { get; set; }

        internal void ApplyTheme(ColorSet themeConfiguration)
        {

            if (colors == null)
            {
                if (themeConfiguration.colors != null && themeConfiguration.colors.Count() > 0)
                {
                    colors = themeConfiguration.colors;
                }
            }

        }

        public override string ToString()
        {

            if (colors != null && colors.Count() > 0)
            {
                string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return ignored.Replace("{", string.Empty).Replace("}", string.Empty) + ",";
            }
            else
            {
                return string.Empty;
            }

        }

    }
}
