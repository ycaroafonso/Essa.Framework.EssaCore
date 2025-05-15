namespace Essa.Framework.Util.Models.Email;

/// <summary>
/// Ycaro Afonso
/// 16/02/2020
/// </summary>
public class EmailSmtpDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Servidor { get; set; }
    public int Porta { get; set; }
    public string EmailDe { get; set; }
    public bool EnableSsl { get; set; } = true;
    public string Dominio { get; set; }

    public TipoSegurancaEnum? TipoSeguranca { get; set; } = TipoSegurancaEnum.SslOnConnect;
}

