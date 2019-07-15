namespace Essa.Framework.WebCore.Controller
{
    using Framework.UtilCore.Models.Controller;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System.Web.Mvc;

    public class CustomJsonBuilder
    {
        private ModelStateDictionary ModelState { get; set; }

        internal IResultModel IResultModel { get; set; }

        public CustomJsonBuilder(IResultModel resultado, ModelStateDictionary modelState)
        {
            ModelState = modelState;
            IResultModel = resultado;
        }

        public CustomJsonBuilder ValidaViewModel()
        {
            if (ModelState.Any(n => n.Value.Errors.Count > 0))
            {
                IResultModel.Situacao = GenericController.SituacaoEnum.ERRO.ToString();
                IResultModel.Mensagem = string.Join("\n", ModelState.Where(n => n.Value.Errors.Count > 0).SelectMany(c => c.Value.Errors.Select(d => d.ErrorMessage)));
            }
            else
                IResultModel.Situacao = GenericController.SituacaoEnum.OK.ToString();

            return this;
        }


    }
}
