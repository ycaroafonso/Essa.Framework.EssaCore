using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Core.Appearance
{
    /// <summary>
    /// Additional CSS styles
    /// </summary>
    [Serializable]
    public class CSSObject
    {

        /// <summary>
        /// The color property is used to set the color of the text.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// Sets all the font properties in one declaration
        /// </summary>
        public string font { get; set; }

        /// <summary>
        /// Specifies the weight of a font
        /// <example>
        /// normal, bold, bolder, lighter, 100, 200, 300...
        /// </example>
        /// </summary>
        public string fontWeight { get; set; }

        /// <summary>
        /// Specifies the font size of text
        /// <example>
        /// xx-small, x-small, small, medium, large...
        /// </example>
        /// </summary>
        public string fontSize { get; set; }

        /// <summary>
        /// Specifies the font family for text
        /// </summary>
        public string fontFamily { get; set; }

        public void CopyStyles(CSSObject model)
        {
            CopyStyles(model, false);
        }

        public void CopyStyles(CSSObject model, bool overrideValues)
        {

            if (model != null)
            {

                if (string.IsNullOrEmpty(color) || overrideValues)
                {
                    color = model.color;
                }

                if (string.IsNullOrEmpty(font) || overrideValues)
                {
                    font = model.font;
                }

                if (string.IsNullOrEmpty(fontWeight) || overrideValues)
                {
                    fontWeight = model.fontWeight;
                }

                if (string.IsNullOrEmpty(fontSize) || overrideValues)
                {
                    fontSize = model.fontSize;
                }

                if (string.IsNullOrEmpty(fontFamily) || overrideValues)
                {
                    fontFamily = model.fontFamily;
                }

            }

        }

    }

}
