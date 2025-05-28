namespace Essa.Framework.Util.Models.Email;

using System;
using System.Collections.Generic;
using System.Linq;

public class EmailDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public int? admenviaemailid { get; set; }
    public bool isgravarnobanco { get; set; } = false;



    public string de { get; set; } = "naoresponda@senarms.org.br";


    public string para { get; set; }
    public List<string> cco { get; set; }
    public List<string> CC { get; set; }


    public string assunto { get; set; }
    public string mensagem { get; set; }

    public List<EmailAnexoDTO> Anexos { get; set; }
    public List<EmailArquivoIncorporadoDTO> ArquivoIncorporado { get; set; }



    public EmailDTO AddAnexo(byte[] arquivobyte, string nome, string contenttype)
    {
        Anexos ??= [];

        Anexos.Add(new EmailAnexoDTO(arquivobyte, nome, contenttype));

        return this;
    }

    public EmailDTO AddArquivoIncorporado(string cid, byte[] imagem, string contentType)
    {

        if (ArquivoIncorporado == null)
            ArquivoIncorporado = new List<EmailArquivoIncorporadoDTO>();

        ArquivoIncorporado.Add(new EmailArquivoIncorporadoDTO(cid, imagem, contentType));

        return this;
    }

    public DateTime DataHoraCadastro { get; set; } = DateTime.Now;




    public string ToLog()
    {
        return string.Concat("Para:", para, ";Assunto:", assunto, ";Anexos:", Anexos == null ? "" : Anexos.Count().ToString(), ";Mensagem:", mensagem);
    }
}

