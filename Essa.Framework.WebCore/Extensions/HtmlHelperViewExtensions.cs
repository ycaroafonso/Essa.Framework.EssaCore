using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Essa.Framework.Web.Extensions
{
    public static class HtmlHelperViewExtensions
    {
        public static IHtmlContent Action<TModel>(this IHtmlHelper helper, string action, string controller, string area, TModel model, object parameters = null)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            if (controller == null)
                throw new ArgumentNullException("controller");


            var result = RenderActionAsync(helper, action, controller, area, model, parameters).GetAwaiter().GetResult();

            return result;
        }
        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller = null, string area = null, object parameters = null)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            if (controller == null)
                throw new ArgumentNullException("controller");


            var result = RenderActionAsync(helper, action, controller, area, parameters).GetAwaiter().GetResult();

            return result;
        }

        private static async Task<IHtmlContent> RenderActionAsync<TModel>(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            // fetching required services for invocation
            var serviceProvider = helper.ViewContext.HttpContext.RequestServices;
            var actionContextAccessor = serviceProvider.GetRequiredService<IActionContextAccessor>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var actionSelector = serviceProvider.GetRequiredService<IActionSelector>();
            var actionCollectionProvider = serviceProvider.GetRequiredService<IActionDescriptorCollectionProvider>();

            // creating new action invocation context
            var routeData = new RouteData();
            foreach (var router in helper.ViewContext.RouteData.Routers)
            {
                routeData.PushState(router, null, null);
            }
            routeData.PushState(null, new RouteValueDictionary(new { controller = controller, action = action, area = area }), null);
            routeData.PushState(null, new RouteValueDictionary(parameters ?? new { }), null);


            //get the actiondescriptor
            RouteContext routeContext = new RouteContext(helper.ViewContext.HttpContext) { RouteData = routeData };

            var originalActionContext = actionContextAccessor.ActionContext;
            var originalhttpContext = httpContextAccessor.HttpContext;
            try
            {
                IReadOnlyList<ActionDescriptor> candidates = actionCollectionProvider.ActionDescriptors.Items.Select(x => x as ControllerActionDescriptor)
                    .Where(x =>
                    string.Equals(x.ControllerName, controller, StringComparison.CurrentCultureIgnoreCase) &&
                    string.Equals(x.ActionName, action, StringComparison.CurrentCultureIgnoreCase)).ToList();

                var actionDescriptor = actionSelector.SelectBestCandidate(routeContext, candidates);

                var newHttpContext = serviceProvider.GetRequiredService<IHttpContextFactory>().Create(helper.ViewContext.HttpContext.Features);
                if (newHttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    newHttpContext.Items.Remove(typeof(IUrlHelper));
                }

                using (newHttpContext.Response.Body = new MemoryStream())
                {
                    var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);
                    actionContextAccessor.ActionContext = actionContext;
                    var invoker = serviceProvider.GetRequiredService<IActionInvokerFactory>().CreateInvoker(actionContext);
                    await invoker.InvokeAsync().ConfigureAwait(false);

                    newHttpContext.Response.Body.Position = 0;
                    using (var reader = new StreamReader(newHttpContext.Response.Body))
                    {
                        return new HtmlString(reader.ReadToEnd());
                    }
                };
            }
            catch (Exception ex)
            {
                return new HtmlString(ex.Message);
            }
            finally
            {
                actionContextAccessor.ActionContext = originalActionContext;
                httpContextAccessor.HttpContext = originalhttpContext;
                if (helper.ViewContext.HttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    helper.ViewContext.HttpContext.Items.Remove(typeof(IUrlHelper));
                }
            }
        }

        private static async Task<IHtmlContent> RenderActionAsync<TModel>(this IHtmlHelper helper, string action, string controller, string area, TModel model, object parameters = null)
        {
            // fetching required services for invocation
            var serviceProvider = helper.ViewContext.HttpContext.RequestServices;
            var actionContextAccessor = serviceProvider.GetRequiredService<IActionContextAccessor>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var actionSelector = serviceProvider.GetRequiredService<IActionSelector>();
            var actionCollectionProvider = serviceProvider.GetRequiredService<IActionDescriptorCollectionProvider>();

            // creating new action invocation context
            var routeData = new RouteData();
            foreach (var router in helper.ViewContext.RouteData.Routers)
            {
                routeData.PushState(router, null, null);
            }
            routeData.PushState(null, new RouteValueDictionary(new { controller = controller, action = action, area = area }), null);
            routeData.PushState(null, new RouteValueDictionary(parameters ?? new { }), null);

            if (model != null)
                routeData.PushState(null, new RouteValueDictionary(model), null);


            //get the actiondescriptor
            RouteContext routeContext = new RouteContext(helper.ViewContext.HttpContext) { RouteData = routeData };

            var originalActionContext = actionContextAccessor.ActionContext;
            var originalhttpContext = httpContextAccessor.HttpContext;
            try
            {
                IReadOnlyList<ActionDescriptor> candidates = actionCollectionProvider.ActionDescriptors.Items.Select(x => x as ControllerActionDescriptor)
                    .Where(x =>
                    string.Equals(x.ControllerName, controller, StringComparison.CurrentCultureIgnoreCase) &&
                    string.Equals(x.ActionName, action, StringComparison.CurrentCultureIgnoreCase)).ToList();

                var actionDescriptor = actionSelector.SelectBestCandidate(routeContext, candidates);

                var newHttpContext = serviceProvider.GetRequiredService<IHttpContextFactory>().Create(helper.ViewContext.HttpContext.Features);
                if (newHttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    newHttpContext.Items.Remove(typeof(IUrlHelper));
                }

                using (newHttpContext.Response.Body = new MemoryStream())
                {
                    var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);
                    actionContextAccessor.ActionContext = actionContext;
                    var invoker = serviceProvider.GetRequiredService<IActionInvokerFactory>().CreateInvoker(actionContext);
                    await invoker.InvokeAsync().ConfigureAwait(false);

                    newHttpContext.Response.Body.Position = 0;
                    using (var reader = new StreamReader(newHttpContext.Response.Body))
                    {
                        return new HtmlString(reader.ReadToEnd());
                    }
                };
            }
            catch (Exception ex)
            {
                return new HtmlString(ex.Message);
            }
            finally
            {
                actionContextAccessor.ActionContext = originalActionContext;
                httpContextAccessor.HttpContext = originalhttpContext;
                if (helper.ViewContext.HttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    helper.ViewContext.HttpContext.Items.Remove(typeof(IUrlHelper));
                }
            }
        }
    }

}
