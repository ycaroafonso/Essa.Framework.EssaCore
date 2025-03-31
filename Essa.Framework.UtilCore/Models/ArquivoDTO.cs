namespace Essa.Framework.Util.Models;

public class ArquivoDTO
{
    public byte[] File { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public long Length { get; set; }
}
