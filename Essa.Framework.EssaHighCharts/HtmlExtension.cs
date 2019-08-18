using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Html;
using Highcharts.Core.Options;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Highcharts.MVC
{
    public static class HtmlHelperExtension
    {
        private static int _id = 0;
        private const string ChartContainer = "<div id=\"chart{0}\"></div>";

        private static string GetScriptDependencyInection()
        {
            _id++;

            var scriptBuilder = new StringBuilder();
            scriptBuilder.AppendLine("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js\"></script>");
            scriptBuilder.AppendLine("<script type=\"text/javascript\" src=\"http://code.highcharts.com/highcharts.js\"></script>");
            scriptBuilder.AppendLine("<script type=\"text/javascript\" src=\"http://code.highcharts.com/modules/exporting.js\"></script>");
            scriptBuilder.AppendLine("<script type=\"text/javascript\" src=\"http://www.highcharts.com/js/themes/grid.js\"></script>");                        

            return scriptBuilder.ToString();
        }

        public static HtmlString AreaChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId)  + 
                         "<script>" + ScriptBuilder.BuildAreaChart(chartOptions) + "</script>";

            return new HtmlString(script);
        }

        public static HtmlString AreaSplineChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                         "<script>" + ScriptBuilder.BuildAreaSplineChart(chartOptions) + "</script>";

            return new HtmlString(script);
        }

        public static HtmlString BarChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                         "<script>" + ScriptBuilder.BuildBarChart(chartOptions) + "</script>";

            return new HtmlString(script);
        }

        public static HtmlString ColumnChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                         "<script>" + ScriptBuilder.BuildColumnChart(chartOptions) + "</script>";

            return new HtmlString(script);
        }

        public static HtmlString LineChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                         "<script>" + ScriptBuilder.BuildLineChart(chartOptions) + "</script>";
            return new HtmlString(script);
        }

        public static HtmlString PieChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                         "<script>" + ScriptBuilder.BuildPieChart(chartOptions) + "</script>";
            return new HtmlString(script);
        }

        public static HtmlString ScatterChartFor(this IHtmlHelper htmlHelper, ChartOptions chartOptions)
        {
            chartOptions.ClientId = string.IsNullOrWhiteSpace(chartOptions.ClientId) ? _id.ToString(CultureInfo.InvariantCulture) : chartOptions.ClientId;

            var script = GetScriptDependencyInection() + string.Format(ChartContainer, chartOptions.ClientId) +
                            "<script>" + ScriptBuilder.BuildScatterChart(chartOptions) + "</script>";

            return new HtmlString(script);
        }
    }
}
