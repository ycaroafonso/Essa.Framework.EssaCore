using System;

namespace Essa.Framework.Util.Models.Interface;

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
    public int? UsuarioIdCadastrado { get; set; }
}
