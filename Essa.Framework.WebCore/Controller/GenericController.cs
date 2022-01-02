namespace Essa.Framework.Web.Controller
{
    using Essa.Framework.Util.Models.Controller;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public interface IGenericController<T>
        where T : class
    {

    }



    public class GenericController : Controller
    {
        protected List<string> Erro
        {
            get
            {
                if (TempData["Erro"] == null) TempData["Erro"] = new List<string>();
                return (List<string>)TempData["Erro"];
            }
            set
            {
                TempData["Erro"] = value;
            }
        }

        public enum SituacaoEnum
        {
            OK,
            ERRO,
        }


        /// <summary>
        /// Retorna um json no padrão do IResultModel com o exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="behavior"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        //protected internal JsonResult Json(Exception exception, object parametros = null)
        //{
        //    return base.Json(new ResultModel { Situacao = "ERRO", Mensagem = exception.ToMensagemErro(), Parametros = parametros });
        //}


        ///// <summary>
        ///// Retorna um json no padrão do IResultModel com o exception
        ///// </summary>
        ///// <param name="exception"></param>
        ///// <param name="behavior"></param>
        ///// <param name="parametros"></param>
        ///// <returns></returns>
        //protected internal JsonResult Json(DbEntityValidationException exception, object parametros = null)
        //{
        //    return base.Json(new ResultModel { Situacao = "ERRO", Mensagem = exception.ToMensagemErro(), Parametros = parametros });
        //}

        //protected internal JsonResult Json(DbUpdateException exception, object parametros = null)
        //{
        //    return base.Json(new ResultModel { Situacao = "ERRO", Mensagem = exception.ToMensagemErro(), Parametros = parametros });
        //}


        /// <summary>
        /// Retorna um json no padrão do IResultModel
        /// </summary>
        /// <param name="situacao"></param>
        /// <param name="behavior"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        protected internal JsonResult Json(SituacaoEnum situacao, object parametros = null)
        {
            return base.Json(new ResultModel { Situacao = situacao.ToString(), Parametros = parametros });
        }




        protected internal JsonResult Json(SituacaoEnum situacao, string mensagem, object parametros)
        {
            return base.Json(new ResultModel { Situacao = situacao.ToString(), Mensagem = mensagem, Parametros = parametros });
        }






        protected FileContentResult PDF(byte[] arq)
        {
            return File(arq, "application/PDF");
        }
        protected FileContentResult XLS(byte[] arq)
        {
            return File(arq, "application/vnd.ms-excel");
        }


    }
}
