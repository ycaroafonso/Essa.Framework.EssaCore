namespace Essa.Framework.Util.Util
{
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Content;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class GenericRest
    {
        protected bool IsSuccessStatusCode { get; private set; } = true;


        Url _url;
        private readonly string _servidor;
        private readonly string _controllerUrl;

        public GenericRest(string servidor, string controllerUrl)
        {
            _url = servidor;
            _servidor = servidor;
            _controllerUrl = controllerUrl;
        }

        string _token = null;
        public void SetToken(string token)
        {
            _token = token;
        }

        protected async Task<T> GetOneAsync<T>(string path, object parametros = null)
        {
            _url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                _url.SetQueryParams(parametros);

            var ret = await _url.GetJsonAsync<T>();

            return ret;
            //      catch (FlurlHttpException ex)
            //{
            //    var status = ex.Call.HttpResponseMessage.StatusCode;
            //    var message = await ex.GetResponseStringAsync();

            //    IsSuccessStatusCode = false;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        protected async Task<IList<dynamic>> GetListAsync(string path, object parametros = null)
        {
            _url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                _url.SetQueryParams(parametros);

            if (!string.IsNullOrEmpty(_token))
                return await _url.WithOAuthBearerToken(_token).GetJsonListAsync();
            else
                return await _url.GetJsonListAsync();
        }


        protected async Task<T> Post<T>(string path, object obj = null)
        {
            _url.AppendPathSegments(_controllerUrl, path);

            Task<IFlurlResponse> ret;

            if (!string.IsNullOrEmpty(_token))
                ret = _url.WithOAuthBearerToken(_token).PostJsonAsync(obj);
            else
                ret = _url.PostJsonAsync(obj);


            IsSuccessStatusCode = ret.IsCompleted;

            return await ret.ReceiveJson<T>();

        }




        protected async Task<T> Post<T>(string path, string filepath, string nomeparametro, string nomearquivo, object obj)
            where T : class
        {
            _url.AppendPathSegments(_controllerUrl, path);

            var ret = await _url.PostMultipartAsync(mp => mp
                   .AddFile(nomeparametro, filepath, fileName: nomearquivo)
                   .AddStringParts(obj)
                   );

            return await ret.GetJsonAsync<T>();
        }

        protected async Task<T> Post<T>(string path, Action<CapturedMultipartContent> buildContent)
            where T : class
        {
            _url.AppendPathSegments(_controllerUrl, path);

            var ret = await _url.PostMultipartAsync(mp => buildContent(mp));

            return await ret.GetJsonAsync<T>();
        }


    }
}
