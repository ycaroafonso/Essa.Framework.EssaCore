namespace Essa.Framework.Util.Models.Email
{
    /// <summary>
    /// Ycaro Afonso
    /// 16/02/2020
    /// </summary>
    public class EmailAnexoDTO
    {
        public EmailAnexoDTO() { }
        public EmailAnexoDTO(byte[] arquivobyte, string nome, string contenttype)
        {
            this.arquivobyte = arquivobyte;
            this.nome = nome;
            this.contenttype = contenttype;
        }

        public byte[] arquivobyte { get; set; }
        public string nome { get; set; }
        public string contenttype { get; set; }
        public string anexoid { get; set; }
    }
}
