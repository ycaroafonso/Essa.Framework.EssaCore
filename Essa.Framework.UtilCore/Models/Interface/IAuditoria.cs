namespace Essa.Framework.Util.Models.Interface
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IAuditoria
    {
        int? auditoriausuarioid { get; set; }

        /// <summary>
        /// Hora UTC
        /// </summary>
        [Column(TypeName = "datetime")]
        DateTime? auditoriadatahora { get; set; }
    }
    public interface IAuditoriaUsuarioCadastro
    {
        public int? usuarioidcadastro { get; set; }
    }
}
