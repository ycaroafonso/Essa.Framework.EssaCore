namespace Essa.Framework.Web.Helpers.Bootstrap.Portlet
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public class PortletBuilder : IDisposable
    {
        private ViewContext _html;


        public PortletBuilder(string id, ViewContext html, string titulo
            , string classPortlet = "portlet box blue"
            , string classIconeTitulo = "fa fa-gift")
        {
            _html = html;

            _html.Writer.Write(string.Format(@"<div class=""{2}"" id=""{1}"">
                            <div class=""portlet-title"">
                                <div class=""caption"">
                                    <i class=""{3}""></i>
                                    {0}
                                </div>
                            </div>
                            <div class=""portlet-body form"">", titulo, id, classPortlet, classIconeTitulo));
        }


        public void Dispose()
        {
            _html.Writer.Write(@"</div></div>");
        }
    }
}
