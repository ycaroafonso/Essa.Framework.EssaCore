//using System.IO;
//using System.Net.Mail;
//using System.Net.Mime;
//using System.Security;
//using System.Threading.Tasks;

//namespace Essa.Framework.Util
//{
//    public class Email
//    {
//        private SmtpClient _smtp;
//        MailMessage _mailMessage;


//        public Email Titulo(string titulo)
//        {
//            _mailMessage.Subject = titulo;

//            return this;
//        }


//        public Email(string userName, string password, string servidor, int porta, string emailDe = null, string domain = null, bool enableSsl = true)
//        {
//            _smtp = new SmtpClient(servidor)
//            {
                
//                EnableSsl = enableSsl,
//                //_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
//                //_smtp.UseDefaultCredentials = false;
                
//                Credentials = new System.Net.NetworkCredential(userName, password, domain)
//            };

//            _mailMessage = new MailMessage();

//            _mailMessage.From = new MailAddress(emailDe ?? userName);
//        }


//        public Email Conteudo(string cont, bool IsBodyHtml)
//        {
//            _mailMessage.Body = cont;
//            _mailMessage.IsBodyHtml = IsBodyHtml;

//            return this;
//        }

//        public Email AddDestinatario(string email)
//        {
//            _mailMessage.To.Add(email);

//            return this;
//        }
//        public Email AddDestinatarioCc(string email)
//        {
//            _mailMessage.CC.Add(email);

//            return this;
//        }

//        public Email AddDestinatarioCco(string email)
//        {
//            _mailMessage.Bcc.Add(email);

//            return this;
//        }


//        public Email AddArquivoIncorporado(string conteudo, string cid, byte[] imagem, string contentType)
//        {
//            MemoryStream image1 = new MemoryStream(imagem);
//            AlternateView av = AlternateView.CreateAlternateViewFromString(conteudo, null, MediaTypeNames.Text.Html);

//            LinkedResource headerImage = new LinkedResource(image1);
//            headerImage.ContentId = cid;
//            headerImage.ContentType = new ContentType(contentType);
//            av.LinkedResources.Add(headerImage);
//            _mailMessage.AlternateViews.Add(av);

//            return this;
//        }


//        public void Enviar()
//        {
//            _smtp.Send(_mailMessage);
//        }

//        public async Task EnviarAsync()
//        {
//            await _smtp.SendMailAsync(_mailMessage);
//        }
//    }
//}
