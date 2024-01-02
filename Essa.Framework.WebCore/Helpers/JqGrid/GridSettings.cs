namespace Essa.Framework.Web.Helpers.JqGrid
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;

    [ModelBinder(typeof(GridModelBinder))]
    public class GridSettings
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public Filter Where { get; set; }
    }

    [DataContract]
    public class Filter
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public Rule[] rules { get; set; }

        public static Filter Create(string jsonData)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(Filter));
                System.IO.StringReader reader = new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsonData));
                return serializer.ReadObject(ms) as Filter;
            }
            catch
            {
                return null;
            }
        }
    }

    [DataContract]
    public class Rule
    {
        [DataMember]
        public string field { get; set; }
        [DataMember]
        public string op { get; set; }
        [DataMember]
        public string data { get; set; }
    }

    public class GridModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            try
            {
                var request = controllerContext.HttpContext.Request;
                return new GridSettings
                {
                    IsSearch = bool.Parse(request.Query["_search"].ToString() ?? "false"),
                    PageIndex = int.Parse(request.Query["page"].ToString() ?? "1"),
                    PageSize = int.Parse(request.Query["rows"].ToString() ?? "10"),
                    SortColumn = request.Query["sidx"].ToString() ?? "",
                    SortOrder = request.Query["sord"].ToString() ?? "asc",
                    Where = Filter.Create(request.Query["filters"].ToString() ?? "")
                };
            }
            catch
            {
                return null;
            }
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var controllerContext = bindingContext.ActionContext;
                var request = controllerContext.HttpContext.Request;

                // Synchronous logic wrapped in a completed task
                var result = new GridSettings
                {
                    IsSearch = bool.Parse(request.Form["_search"].ToString() ?? "false"),
                    PageIndex = int.Parse(request.Form["page"].ToString() ?? "1"),
                    PageSize = int.Parse(request.Form["rows"].ToString() ?? "10"),
                    SortColumn = request.Form["sidx"].ToString() ?? "",
                    SortOrder = request.Form["sord"].ToString() ?? "asc",
                    Where = Filter.Create(request.Form["filters"].ToString() ?? "")
                };

                // Set the result in ModelBindingContext.Result
                bindingContext.Result = ModelBindingResult.Success(result);

                // Return a completed task
                return Task.CompletedTask;
            }
            catch
            {
                // Return a completed task with a null result in case of an exception
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
        }

    }
}