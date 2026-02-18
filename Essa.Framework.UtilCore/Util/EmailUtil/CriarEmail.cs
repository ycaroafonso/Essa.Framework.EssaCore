using Essa.Framework.Util.Models.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Essa.Framework.Util.Util.EmailUtil.EmailUtil
{
    public class CriarEmail : IDisposable
    {
        public SmtpClient Client { get; set; }


        MimeMessage _mailMessage;
        private EmailSmtpDTO emailSmtpDTO;
        private BodyBuilder body;
        private readonly CancellationToken _ct;
        private readonly EmailSmtpDTO _emailSmtp;

        public CriarEmail Titulo(string titulo)
        {
            _mailMessage.Subject = titulo ?? "";

            return this;
        }


        public CriarEmail(string userName, string password, string servidor, int porta, string emailDe = null, string dominio = null, bool enableSsl = true
            , TipoSegurancaEnum? tipoSeguranca = TipoSegurancaEnum.StartTls
            , CancellationToken ct = default)
        {
            _ct = ct;


            Client = new SmtpClient()
            {
                LocalDomain = dominio,
            };
            Client.Connect(servidor, porta, (SecureSocketOptions)tipoSeguranca, ct);
            Client.Authenticate(userName, password, ct);


            body = new BodyBuilder();

        }

        public CriarEmail(EmailSmtpDTO emailSmtp)
            : this(emailSmtp.UserName, emailSmtp.Password, emailSmtp.Servidor, emailSmtp.Porta, emailSmtp.EmailDe, emailSmtp.Dominio, emailSmtp.EnableSsl, emailSmtp.TipoSeguranca)
        {
            if (emailSmtp is null)
            {
                throw new ArgumentNullException(nameof(emailSmtp));
            }

            _emailSmtp = emailSmtp;
        }


        public void IniciarEnvio()
        {
            _mailMessage = new MimeMessage();
            _mailMessage.From.Add(new MailboxAddress(_emailSmtp.EmailDe ?? _emailSmtp.UserName, _emailSmtp.EmailDe ?? _emailSmtp.UserName));
        }


        public CriarEmail Conteudo(string cont, bool IsBodyHtml)
        {
            if (IsBodyHtml)
                body.HtmlBody = cont;
            else
                body.TextBody = cont;

            return this;
        }

        public CriarEmail AddDestinatario(string email)
        {
            _mailMessage.To.Add(new MailboxAddress(email, email));

            return this;
        }
        public CriarEmail AddDestinatarioCc(string email)
        {
            _mailMessage.Cc.Add(new MailboxAddress(email, email));

            return this;
        }

        public CriarEmail AddDestinatarioCco(string email)
        {
            _mailMessage.Bcc.Add(new MailboxAddress(email, email));

            return this;
        }


        public CriarEmail AddArquivoIncorporado(string conteudo, string cid, byte[] imagem, string contentType)
        {
            MimeEntity linkedResources = body.LinkedResources.Add(cid, imagem, new ContentType(contentType.Split("/")[0], contentType.Split("/")[1]));
            linkedResources.ContentId = cid;

            return this;
        }


        public void Enviar()
        {
            _mailMessage.Body = body.ToMessageBody();

            Client.Send(_mailMessage);
        }

        public async Task EnviarAsync()
        {
            _mailMessage.Body = body.ToMessageBody();

            var x = await Client.SendAsync(_mailMessage);
            var a = 1;
        }

        public void Dispose()
        {
            Client.Disconnect(true, _ct);
        }
    }
}
