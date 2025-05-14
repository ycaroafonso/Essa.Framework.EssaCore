namespace Essa.Framework.Util.Models.Email
{
    public class EmailArquivoIncorporadoDTO
    {
        public EmailArquivoIncorporadoDTO(string cid, byte[] imagem, string contentType)
        {
            CID = cid;
            Imagem = imagem;
            ContentType = contentType;
        }

        public string CID { get; }
        public byte[] Imagem { get; }
        public string ContentType { get; }
    }
}
