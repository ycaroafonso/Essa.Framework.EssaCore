using System;

namespace Highcharts.Core
{
    [Serializable]    
    public class AJAXSource
    {

        public string clientId { get; set; }
        public string source { get; set; }
        public int delay { get; set; }
        public bool clearAll { get; set; }
        public bool onlyOnce { get; set; }
        public bool shift { get; set; }
        public string customFunction { get; set; }

        public AJAXSource()
        { 
            this.delay = 500;
            this.clearAll = false;
            this.onlyOnce = false;
            this.shift = false;
        }
        public AJAXSource(string source)
        {
            this.source = source;
            this.delay = 500;
            this.clearAll = false;
            this.onlyOnce = false;
            this.shift = false;
        }

        public AJAXSource(string source, int uSeconds)
        {
            this.source = source;
            this.delay = uSeconds;
            this.clearAll = false;
            this.onlyOnce = false;
            this.shift = false;
        }

        public AJAXSource(string source, int uSeconds, bool clearAll, bool onlyOnce, bool shift)
        {
            this.source = source;
            this.delay = uSeconds;
            this.clearAll = clearAll;
            this.onlyOnce = onlyOnce;
            this.shift = shift;
        }

        public override string ToString()
        {

            string script = "";

            if (!string.IsNullOrEmpty(customFunction))
                script = String.Format("function(){{ {0} }}", customFunction);
            else
            {
                script = @"chart[@Id]_JSONUpdate = function() {
                jQuery.get('[@DataSource]', function (data) {
		            var allSeries = jQuery.parseJSON(data);
            "
                +
                ((clearAll) ?
                    // remove all existing series
                    @"for (var i = 0; i < chart[@Id].series.length; i++) {
		            chart[@Id].series[i].remove(true);
                }"
                    :
                    ""
                )
                +
                 @"
		            //// Iterate over the lines and add categories or series
		            jQuery.each(allSeries, function (recordNo, currentSerie) {
		                
                        // if there is no serie added to the chart
                        // ,insert the one just received
                        if(typeof(chart[@Id].series[0]) == 'undefined')
                            chart[@Id].addSeries(currentSerie);
                        else
                        {
                            var serieToUpdate = new Object();
                            if(typeof(currentSerie.id) != 'undefined')
                                serieToUpdate = chart[@Id].get(currentSerie.id);    // if 'id' is defined for the serie, try to update corresponding chart serie
                            else
                                serieToUpdate = chart[@Id].series[0];   // if 'id' is not defined, update the first serie that you can find
                            
                            if(typeof(serieToUpdate) != 'undefined')
                            {
                                jQuery.each(currentSerie.data, function (pointNo, point) {
                                    serieToUpdate.addPoint(point, false, " + shift.ToString().ToLower() + @");
                                });
                            }
                        }
                    });
                    chart[@Id].redraw();
		        });     
            };
            " +
                 ((onlyOnce) ?
                "setTimeout(function() {"
                :
                "setInterval(function() {"
                ) + @"
                chart[@Id]_JSONUpdate();
            }, " + delay + ");";
            
            }

            if (!string.IsNullOrEmpty(this.source))
                return script.Replace("[@DataSource]", this.source);
            else
                return "";        
        }

    }
}



/*

        public override string ToString()
        {

            string script =
            ((onlyOnce) ?
            "setTimeout(function() {"
            :
            "setInterval(function() {"
            )
            +
            @"            
                jQuery.get('[@DataSource]', function (data) {
		            var allSeries = jQuery.parseJSON(data);
            "
            +
            ((clearAll) ?
                // remove all existing series
                @"for (var i = 0; i < chart[@Id].series.length; i++) {
		            chart[@Id].series[i].remove(true);
                }"
                :
                ""
            )
            +
             @"
		            //// Iterate over the lines and add categories or series
		            jQuery.each(allSeries, function (recordNo, currentSerie) {
		                if(typeof(chart[@Id].series[0]) == 'undefined')
                            chart[@Id].addSeries(currentSerie);
                        else
                        {
                            var serieToUpdate = new Object();
                            if(typeof(currentSerie.id) != 'undefined')
                                serieToUpdate = chart[@Id].get(currentSerie.id);
                            else
                                serieToUpdate = chart[@Id].series[0];
                            
                            if(typeof(serieToUpdate) != 'undefined')
                            {
                                jQuery.each(currentSerie.data, function (pointNo, point) {
                                    serieToUpdate.addPoint(point, false, " + shift.ToString().ToLower() + @");
                                });
                            }
                        }
                    });
                    chart[@Id].redraw();
		        });     
            }, " + delay + ");";



            if (!string.IsNullOrEmpty(this.source))
                return script.Replace("[@DataSource]", this.source);
            else
                return "";        
        }

    }
*/