using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Essa.Framework.Util;

public class Email
{
    private readonly System.Net.NetworkCredential _credencial;
    private readonly SmtpClient _smtp;
    private readonly MailMessage _mailMessage;

    public Email(string userName, string password, string servidor, int porta, string emailDe = null, string nomeDe = null, bool enableSsl = true, bool useDefaultCredentials = false)
    {
        _credencial = new System.Net.NetworkCredential(userName, password);
        _smtp = new SmtpClient(servidor, porta)
        {
            EnableSsl = enableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = useDefaultCredentials,
            Credentials = _credencial
        };

        _mailMessage = new MailMessage
        {
            From = string.IsNullOrWhiteSpace(nomeDe)
                ? new MailAddress(emailDe ?? userName)
                : new MailAddress(emailDe ?? userName, nomeDe)
        };
    }

    public Email Titulo(string titulo) { _mailMessage.Subject = titulo; return this; }
    public Email Conteudo(string cont, bool isBodyHtml) { _mailMessage.Body = cont; _mailMessage.IsBodyHtml = isBodyHtml; return this; }
    public Email AddDestinatario(string email) { _mailMessage.To.Add(email); return this; }
    public Email AddDestinatarioCc(string email) { _mailMessage.CC.Add(email); return this; }
    public Email AddDestinatarioCco(string email) { _mailMessage.Bcc.Add(email); return this; }

    public Email AddArquivoIncorporado(string conteudo, string cid, byte[] imagem, string contentType)
    {
        var image1 = new MemoryStream(imagem);
        var av = AlternateView.CreateAlternateViewFromString(conteudo, null, MediaTypeNames.Text.Html);
        var headerImage = new LinkedResource(image1) { ContentId = cid, ContentType = new ContentType(contentType) };
        av.LinkedResources.Add(headerImage);
        _mailMessage.AlternateViews.Add(av);
        return this;
    }

    public void Enviar() => _smtp.Send(_mailMessage);
    public Task EnviarAsync() => _smtp.SendMailAsync(_mailMessage);
}
