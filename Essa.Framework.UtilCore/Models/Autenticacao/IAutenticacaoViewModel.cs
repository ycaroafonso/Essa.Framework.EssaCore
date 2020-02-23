namespace Essa.Framework.Util.Models.Autenticacao
{
    using System;


    public interface IAutenticacaoViewModel
    {
        string Login { get; set; }
        string Senha { get; set; }
        int PortalModuloId { get; set; }

        bool IsVerificarIp { get; set; }

        string Ip { get; set; }

        DateTime Data { get; set; }

        string Hash { get; set; }

        string ToString();
    }
}
