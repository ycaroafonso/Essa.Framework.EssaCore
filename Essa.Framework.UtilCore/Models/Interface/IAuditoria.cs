namespace Essa.Framework.Util.Models.Interface
{
    using System;


    public interface IAuditoria
    {
        int? auditoriausuarioid { get; set; }
        DateTime? auditoriadatahora { get; set; }
    }
    public interface IAuditoriaUsuarioCadastro
    {
        public int? usuarioidcadastro { get; set; }
    }
}
