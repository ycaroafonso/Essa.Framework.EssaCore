using System.Globalization;
using System.Text;
using System.Linq;
using Highcharts.Core;
using Highcharts.Core.Options;

namespace Highcharts.MVC
{
    internal class ScriptBuilder
    {
        #region Private Methods
        private static string DefaultScriptBuilder(ChartOptions chartOptions, RenderType renderType, params string[] aditionalScriptData)
        {
            const string themeApi = @"var highchartsOptions = Highcharts.setOptions(themes['{0}']);";

            chartOptions.Appearance.renderTo = "chart" + chartOptions.ClientId;
            chartOptions.Appearance.defaultSeriesType = renderType.ToString();

            var scriptBuilder = new StringBuilder();
            scriptBuilder.Append("var chart");

            scriptBuilder.Append(chartOptions.ClientId);
            scriptBuilder.AppendLine(";");

            scriptBuilder.AppendLine("$(document).ready(function() {");
            scriptBuilder.AppendLine(chartOptions.Lang.ToString());

            scriptBuilder.Append("chart");
            scriptBuilder.Append(chartOptions.ClientId);
            scriptBuilder.AppendLine(" = new Highcharts.Chart({");

            aditionalScriptData.ToList().ForEach(ad => scriptBuilder.AppendLine(ad));

            scriptBuilder.AppendLine(chartOptions.Appearance != null ? chartOptions.Appearance.ToString() : string.Empty);
            scriptBuilder.AppendLine(chartOptions.Colors != null ? chartOptions.Colors.ToString() : string.Empty);
            scriptBuilder.AppendLine("credits: { enabled: ");
            scriptBuilder.Append(chartOptions.ShowCredits.ToString(CultureInfo.InvariantCulture).ToLower());
            scriptBuilder.Append("},");
            scriptBuilder.AppendLine(chartOptions.PlotOptions != null ? chartOptions.PlotOptions.ToString() : string.Empty);
            scriptBuilder.AppendLine(chartOptions.Title != null ? chartOptions.Title.ToString() : string.Empty);
            scriptBuilder.AppendLine(chartOptions.SubTitle != null ? chartOptions.SubTitle.ToString() : string.Empty);
            scriptBuilder.AppendLine(chartOptions.Legend != null ? chartOptions.Legend.ToString() : string.Empty);
            scriptBuilder.AppendLine(chartOptions.Exporting.ToString());
            scriptBuilder.AppendLine(chartOptions.XAxis.ToString());
            scriptBuilder.AppendLine(chartOptions.YAxis.ToString());
            scriptBuilder.AppendLine(chartOptions.Tooltip.ToString());
            scriptBuilder.AppendLine(chartOptions.Series.ToString());
            scriptBuilder.AppendLine("});");
            scriptBuilder.AppendLine(chartOptions.AjaxDataSource.ToString());
            scriptBuilder.AppendLine("});");

            var reg = new System.Text.RegularExpressions.Regex(@"\""(function\(event\)\{.*?\})\""",
                                                               System.Text.RegularExpressions.RegexOptions.Multiline);

            var script = reg.Replace(scriptBuilder.ToString(), "$1");

            return string.IsNullOrEmpty(chartOptions.Theme)
                       ? script
                       : string.Concat(string.Format(themeApi, chartOptions.Theme), script);
        }
        #endregion

        #region ChartBuilder
        internal static string BuildAreaChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.area);
        }

        internal static string BuildScatterChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.scatter);
        }

        internal static string BuildPieChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.pie);
        }

        internal static string BuildLineChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.line);
        }

        internal static string BuildAreaSplineChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.areaspline);
        }

        internal static string BuildBarChart(ChartOptions chartOptions)
        {
            return DefaultScriptBuilder(chartOptions, RenderType.bar);
        }

        internal static string BuildColumnChart(ChartOptions chartOptions)
        {
            const string columnChartOptions = @"chart: { renderTo: '[@Id]', defaultSeriesType: '[@RenderType]' },";
            return DefaultScriptBuilder(chartOptions, RenderType.column, columnChartOptions);
        }
        #endregion

        #region SourceBuilder
        internal static string AjaxSourceScriptBuilder(AJAXSource ajaxSource)
        {
            if (string.IsNullOrWhiteSpace(ajaxSource.source))
                return "";

            if (!string.IsNullOrEmpty(ajaxSource.customFunction))
                return string.Format("function(){{ {0} }}", ajaxSource.customFunction).Replace("[@DataSource]", ajaxSource.source);

            var scriptBuilder = new StringBuilder();

            scriptBuilder.Append(@"chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.Append(@"_JSONUpdate = function() {jQuery.get('");
            scriptBuilder.Append(ajaxSource.source);
            scriptBuilder.AppendLine(@"', function (data) {var allSeries = jQuery.parseJSON(data);");

            if (ajaxSource.clearAll)
            {
                scriptBuilder.Append(@"for (var i = 0; i < chart");
                scriptBuilder.Append(ajaxSource.clientId);
                scriptBuilder.Append(".series.length; i++) {chart");
                scriptBuilder.Append(ajaxSource.clientId);
                scriptBuilder.AppendLine(".series[i].remove(true);}");
            }

            scriptBuilder.AppendLine(@"jQuery.each(allSeries, function (recordNo, currentSerie) {");
            
            scriptBuilder.Append("if(typeof(chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.AppendLine(".series[0]) == 'undefined')");

            scriptBuilder.Append("chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.AppendLine(".addSeries(currentSerie);");
            scriptBuilder.AppendLine("else");
            scriptBuilder.AppendLine("{");
            scriptBuilder.AppendLine("var serieToUpdate = new Object();");
            scriptBuilder.AppendLine("if(typeof(currentSerie.id) != 'undefined')");
            scriptBuilder.Append("serieToUpdate = chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.AppendLine(".get(currentSerie.id);");
            scriptBuilder.AppendLine("else");
            scriptBuilder.Append("serieToUpdate = chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.Append(".series[0];");
            scriptBuilder.AppendLine("if(typeof(serieToUpdate) != 'undefined')");
            scriptBuilder.AppendLine("{");
            scriptBuilder.AppendLine("jQuery.each(currentSerie.data, function (pointNo, point) {");
            scriptBuilder.Append("serieToUpdate.addPoint(point, false, ");

            scriptBuilder.AppendLine(ajaxSource.shift.ToString(CultureInfo.InvariantCulture).ToLower());
            scriptBuilder.Append(@");});}}});chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.AppendLine(".redraw();});};");
            scriptBuilder.AppendLine((ajaxSource.onlyOnce) ? "setTimeout(function() {" : "setInterval(function() {");
            scriptBuilder.Append(@"chart");
            scriptBuilder.Append(ajaxSource.clientId);
            scriptBuilder.AppendLine("_JSONUpdate();}, ");
            scriptBuilder.AppendLine(ajaxSource.delay.ToString(CultureInfo.InvariantCulture));
            scriptBuilder.Append(");");

            return scriptBuilder.ToString();
        }

        #endregion
    }
}
