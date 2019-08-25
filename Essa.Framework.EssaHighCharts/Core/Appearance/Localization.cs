using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Highcharts.Core.Appearance
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class Localization
    {
        public void LoadDefaults()
        {

            decimalPoint = ".";
            downloadPNG = "Download PNG image";
            downloadJPEG = "Download JPEG image";
            downloadPDF = "Download PDF document";
            downloadSVG = "Download SVG vector image";
            exportButtonTitle = "Export to raster or vector image";
            loading = "Loading...";

            months = new string[]
                         {
                             "January", "February", "March", "April", "May", "June", "July",
                             "August", "September", "October", "November", "December"
                         };

            shortMonths = new string[]
                              {
                                  "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                  "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                              };

            printButtonTitle = "Print the chart";
            resetZoom = "Reset zoom";
            resetZoomTitle = "Reset zoom level 1:1";
            thousandsSep = ",";
            weekdays = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        }

        public string decimalPoint;
        public string downloadPNG;
        public string downloadJPEG;
        public string downloadPDF;
        public string downloadSVG;
        public string exportButtonTitle;
        public string loading;

        public string[] months;

        public string[] shortMonths;

        public string printButtonTitle;
        public string resetZoom;
        public string resetZoomTitle;
        public string thousandsSep;
        public string[] weekdays;

        public override string ToString()
        {
            string ignored = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return @"Highcharts.setOptions({
                        lang: " + ignored + 
                    "});";
        }
    }
}
