using Essa.Framework.Mensageria;
using EssaGestaoCore.DTO.Email;
using EssaGestaoCore.DTO.MensageriaUtil;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Essa.Framework.Web.Util;

public class MeuEmailSender(IConexaoMensageria conexaoMensageria) : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {

        using var fila = await conexaoMensageria.NovaFila();
        await fila.CriarFila(MensageriaNome.essagestao_work_EnviarEmail);
        await fila.Publicar( new EmailDTO
        {
            Assunto = subject,
            Mensagem = htmlMessage,
            Para = new List<string> { email }
        });

    }
}
