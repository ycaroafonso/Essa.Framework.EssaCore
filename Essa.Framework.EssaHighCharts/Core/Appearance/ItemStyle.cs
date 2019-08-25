using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Highcharts.Core.Appearance
{
    [Serializable]
    public class ItemStyle
    {
        /// <summary>
        /// The color property is used to set the color of the text.
        /// </summary>
        public string color { get; set; }

        public void CopyStyles(ItemStyle model)
        {
            CopyStyles(model, false);
        }

        public void CopyStyles(ItemStyle model, bool overrideValues)
        {
            if (model != null)
            {
                if (string.IsNullOrEmpty(color) || overrideValues)
                {
                    color = model.color;
                }
            }

        }
        
    }
}
