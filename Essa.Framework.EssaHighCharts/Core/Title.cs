using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Highcharts.Core.Appearance;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]    
    public class Title
    {
        public Align? align { get; set; }
        public int? margin { get; set; }
        public int? rotation { get; set; }
        public CSSObject style { get; set; }
        public string text { get; set; }
        
        internal void ApplyTheme(CSSObject themeConfiguration)
        {
            style.CopyStyles(themeConfiguration);
        }

        public Title(string titleText)
        {
            text = titleText;            
        }

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore});
            return string.Format("title: {0},", ignored);            
        }

    }
}
