namespace Essa.Framework.UtilCore.Models.Controller
{
    public interface IResultModel
    {
        string Situacao { get; set; }
        string Mensagem { get; set; }
        object Parametros { get; set; }
    }

    public class ResultModel : IResultModel
    {
        public string Situacao { get; set; }
        public string Mensagem { get; set; }
        public object Parametros { get; set; }
    }
}
