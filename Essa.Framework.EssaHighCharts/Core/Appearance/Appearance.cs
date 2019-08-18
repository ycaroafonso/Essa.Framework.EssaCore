using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Core;
using Newtonsoft.Json;

namespace Highcharts.Core.Appearance
{
    [Serializable]
    public class Appearance
    {
                
        public string renderTo { get; set; }
        public string defaultSeriesType { get; set; }
        
        /// <summary>
        /// When using multiple axis, the ticks of two or more opposite axes will automatically be aligned by adding ticks to the axis or axes with the least ticks. This can be prevented by setting alignTicks to false. 
        /// If the grid lines look messy, it's a good idea to hide them for the secondary axis by setting gridLineWidth to 0. Defaults to true.
        /// </summary>
        public bool? alignTicks  { get; set; }

        /// <summary>
        /// Set the overall animation for all chart updating. Animation can be disabled throughout the chart by setting it to false here. 
        /// The only animation not affected by this option is the initial series animation, see PlotOptions.series => animation
        /// </summary>
        public bool? animation { get; set; }

        /// <summary>
        /// The background color or gradient for the outer chart area. Defaults to "#FFFFFF".
        /// </summary>
        public Background backgroundColor { get; set; }

        /// <summary>
        /// The color of the outer chart border. The border is painted using vector graphic techniques to allow rounded corners. Defaults to "#4572A7".
        /// </summary>
        public string borderColor { get; set; }

        /// <summary>
        /// The pixel width of the outer chart border. The border is painted using vector graphic techniques to allow rounded corners. Defaults to 0.
        /// </summary>
        public int? borderWidth { get; set; }

        /// <summary>
        /// The corner radius of the outer chart border. Defaults to 5.
        /// </summary>
        public int? borderRadius { get; set; }

        /// <summary>
        /// A CSS class name to apply to the charts container div, allowing unique CSS styling for each chart. Defaults to "".
        /// </summary>
        public string className { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Events.ChartEvents events { get; set; }
        
        /// <summary>
        /// Additional CSS styles to apply inline to the container div. 
        /// Note that since the default font styles are applied in the renderer, it is ignorant of the individual chart options and must be set globally.
        /// </summary>
        public CSSObject style { get; set; }

        /// <summary>
        /// If true, the axes will scale to the remaining visible series once one series is hidden. 
        /// If false, hiding and showing a series will not affect the axes or the other series. 
        /// For stacks, once one series within the stack is hidden, the rest of the stack will close in around it even if the axis is not affected. 
        /// Defaults to true.
        /// </summary>
        public bool? ignoreHiddenSeries { get; set; }

        /// <summary>D:\Highchart\Highchart.UI\Core\Appearance\ItemStyle.cs
        /// Whether to invert the axes so that the x axis is horizontal and y axis is vertical. 
        /// When true, the x axis is reversed by default. 
        /// If a bar plot is present in the chart, it will be inverted automatically. 
        /// Defaults to false.
        /// </summary>
        public bool? inverted { get; set; }

        /// <summary>
        /// The margin between the outer edge of the chart and the plot area. 
        /// The numbers in the array designate top, right, bottom and left respectively. 
        /// Use the options marginTop, marginRight, marginBottom and marginLeft for shorthand setting of one option.
        /// Since version 2.1, the margin is 0 by default. 
        /// The actual space is dynamically calculated from the offset of axis labels, axis title, title, subtitle and legend in addition to the spacingTop, spacingRight, spacingBottom and spacingLeft options.
        /// Defaults to [null].
        /// </summary>
        public int[] margin { get; set; }

        /// <summary>
        /// The margin between the top outer edge of the chart and the plot area. 
        /// Use this to set a fixed pixel value for the margin as opposed to the default dynamic margin. 
        /// See also spacingTop. Defaults to null.
        /// </summary>
        public int? marginTop { get; set; }

        /// <summary>
        /// The margin between the right outer edge of the chart and the plot area. 
        /// Use this to set a fixed pixel value for the margin as opposed to the default dynamic margin. 
        /// See also spacingRight. Defaults to 50.
        /// </summary>
        public int? marginRight { get; set; }

        /// <summary>
        /// The margin between the bottom outer edge of the chart and the plot area. 
        /// Use this to set a fixed pixel value for the margin as opposed to the default dynamic margin. 
        /// See also spacingBottom. Defaults to 70.
        /// </summary>
        public int? marginBottom { get; set; }

        /// <summary>
        /// The margin between the left outer edge of the chart and the plot area. 
        /// Use this to set a fixed pixel value for the margin as opposed to the default dynamic margin. 
        /// See also spacingLeft. Defaults to 80.
        /// </summary>
        public int? marginLeft { get; set; }

        /// <summary>
        /// Whether to apply a drop shadow to the outer chart area.
        /// Requires that backgroundColor be set. Defaults to false.
        /// </summary>
        public bool? shadow  { get; set; }

        /// <summary>
        /// Whether to show the axes initially. 
        /// This only applies to empty charts where series are added dynamically, as axes are automatically added to cartesian series. 
        /// Defaults to false.
        /// </summary>
        public bool? showAxes  { get; set; }

        /// <summary>
        /// The URL for an image to use as the plot background. 
        /// To set an image as the background for the entire chart, set a CSS background image to the container element. 
        /// Defaults to null.
        /// </summary>
        public string plotBackgroundImage  { get; set; }

        /// <summary>
        /// The background color or gradient for the plot area. Defaults to null.
        /// </summary>
        public Background plotBackgroundColor { get; set; }

        /// <summary>
        /// The color of the inner chart or plot area border. Defaults to "#C0C0C0".
        /// </summary>
        public string plotBorderColor  { get; set; }

        /// <summary>
        /// The pixel width of the plot area border. Defaults to 0.
        /// </summary>
        public int? plotBorderWidth  { get; set; }

        /// <summary>
        /// Whether to apply a drop shadow to the plot area. Requires that plotBackgroundColor be set. Defaults to false.
        /// </summary>
        public bool? plotShadow  { get; set; }

        /// <summary>
        /// Zoom type for the axes
        /// </summary>
        public string zoomType { get; set; }

        public override string ToString()
        {

            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });           
            return string.Format("chart: {0},", ignored);

        }

        internal void ApplyTheme(Appearance themeConfiguration)
        {

            ApplyTheme(themeConfiguration, false);

        }

        internal void ApplyTheme(Appearance themeConfiguration, bool overrideValues)
        {

            if (themeConfiguration != null)
            {

                if (!marginBottom.HasValue || overrideValues)
                {
                    marginBottom = themeConfiguration.marginBottom;
                }

                if (!marginLeft.HasValue || overrideValues)
                {
                    marginLeft = themeConfiguration.marginLeft;
                }

                if (!marginTop.HasValue || overrideValues)
                {
                    marginTop = themeConfiguration.marginTop;
                }

                if (!marginRight.HasValue || overrideValues)
                {
                    marginRight = themeConfiguration.marginRight;
                }

                if (!alignTicks.HasValue || overrideValues)
                {
                    alignTicks = themeConfiguration.alignTicks;
                }

                if (!borderWidth.HasValue || overrideValues)
                {
                    borderWidth = themeConfiguration.borderWidth;
                }

                if (!borderRadius.HasValue || overrideValues)
                {
                    borderRadius = themeConfiguration.borderRadius;
                }

                if (backgroundColor == null || overrideValues)
                {
                    backgroundColor = themeConfiguration.backgroundColor;
                }

                if (!string.IsNullOrEmpty(borderColor) || overrideValues)
                {
                    borderColor = themeConfiguration.borderColor;
                }

                if (string.IsNullOrEmpty(zoomType))
                {
                    zoomType = "";
                }
            }

        }

    }
}
