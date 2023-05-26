namespace Essa.Framework.Util.Models.Interface
{
    using System;


    public interface IAuditoria
    {
        int? auditoriausuarioid { get; set; }

        /// <summary>
        /// Hora UTC
        /// </summary>
        DateTime? auditoriadatahora { get; set; }
    }
    public interface IAuditoriaUsuarioCadastro
    {
        public int? usuarioidcadastro { get; set; }
    }
}
