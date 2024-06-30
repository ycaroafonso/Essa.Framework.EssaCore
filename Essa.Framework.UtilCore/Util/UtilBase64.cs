using System.Linq;

namespace Essa.Framework.Util.Util
{
    public static class UtilBase64
    {

        public static string GetFileExtensionFromBase64(string base64String)
        {
            var data = base64String[..5];

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "R0LGO":
                    return "gif";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }

        public static string ObterMimeTypePeloNomeDoArquivo(string nomeArquivo)
        {
            var mimeType = "application/octet-stream";

            if (string.IsNullOrEmpty(nomeArquivo) || !nomeArquivo.Contains("."))
                return mimeType;

            var extensao = nomeArquivo.Split('.').Last().Replace(".", "");
            extensao = extensao.ToLower();

            switch (extensao)
            {
                case "pdf":
                case "p7s":
                    mimeType = "application/pdf";
                    break;
                case "xls":
                case "xlsx":
                    mimeType = "application/ms-excel";
                    break;
                case "doc":
                case "docx":
                    mimeType = "application/msword";
                    break;
                case "ppt":
                case "pptx":
                    mimeType = "application/ms-powerpoint";
                    break;
                case "rtf":
                    mimeType = "application/rtf";
                    break;
                case "zip":
                    mimeType = "application/zip";
                    break;
                case "mp3":
                    mimeType = "audio/mpeg";
                    break;
                case "mp4":
                    mimeType = "video/mp4";
                    break;
                case "bmp":
                    mimeType = "image/bmp";
                    break;
                case "gif":
                    mimeType = "image/gif";
                    break;
                case "jpg":
                case "jpeg":
                    mimeType = "image/jpeg";
                    break;
                case "png":
                    mimeType = "image/png";
                    break;
                case "tiff":
                case "tif":
                    mimeType = "image/tiff";
                    break;
                case "txt":
                    mimeType = "text/plain";
                    break;
            }

            return mimeType;
        }

    }
}
