namespace Essa.Framework.Util.Extensions
{
    using Extensions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class UtilExtension
    {
        public static int ToInt32(this object valor)
        {
            return Convert.ToInt32(valor);
        }

        //public static byte[] ToByteArray(this object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bf.Serialize(ms, obj);
        //        return ms.ToArray();
        //    }
        //}

        public static bool IfNegative<T>(this T value) where T : IComparable<T>
        {
            return value.CompareTo(default(T)) < 0;
        }

        public static T IfNegative<T>(this T value, Func<T, T> actionReturn) where T : IComparable<T>
        {
            return value.IfNegative() ? actionReturn(value) : value;
        }

        public static T IfNull<T>(this T value, T ret)
        {
            return value == null ? ret : value;
        }

        public static Ret IfNull<T, Ret>(this T value, Ret valorSeNull, Func<T, Ret> valorfalse)
        {
            if (value == null)
                return valorSeNull;
            else
                return valorfalse(value);
        }



        #region IfOnly

        public static T IfOnly<T>(this T value, bool condit, T ret)
        {
            return condit ? ret : value;
        }
        public static T IfOnly<T>(this T value, Func<T, bool> condit, T ret)
        {
            return condit(value) ? ret : value;
        }

        /// <summary>
        /// Compara as key de um dictionary e retorna value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static T IfOnly<T>(this T value, Dictionary<T, T> ret)
        {
            if (ret.ContainsKey(value))
                return ret[value];

            return value;
        }


        /// <summary>
        /// Compara as key de um dictionary e retorna value, se não existir, retorna o parâmetro valorelse;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="value"></param>
        /// <param name="ret"></param>
        /// <param name="valorelse"></param>
        /// <returns></returns>
        public static V IfOnly<T, V>(this T value, Dictionary<T, V> ret, V valorelse)
        {
            if (ret.ContainsKey(value))
                return ret[value];

            return valorelse;
        }

        #endregion


        public static byte[] ToByteArray(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }



        public static Dictionary<int, T> ToDictionary<T>(this T[] lista)
        {
            return lista.Select((item, index) => new { index, item }).ToDictionary(c => c.index, d => d.item);
        }

        public static T IfContainsOnlyOne<T>(this IEnumerable<T> lista)
        {
            if (lista.Count() == 1)
                return lista.Single();
            return default(T);
        }

        public static T[] Remove<T>(this T[] arr, T itemRemover)
        {
            var lista = arr.ToList();
            lista.Remove(itemRemover);
            return lista.ToArray();
        }

        public static string NomeSemExtensao(this FileInfo fileInfo)
        {
            return fileInfo.Name.Replace(fileInfo.Extension, "");
        }


        public static string ResolveNomeArquivo(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("A entrada não pode ser nula ou vazia.");

            // Obter a lista de caracteres inválidos para nomes de arquivos
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Criar um padrão Regex para os caracteres inválidos
            string invalidPattern = $"[{Regex.Escape(new string(invalidChars))}]";

            // Substituir caracteres inválidos por "_"
            string validFileName = Regex.Replace(fileName, invalidPattern, "_");

            // Opcional: Remover espaços em excesso
            validFileName = Regex.Replace(validFileName, @"\s+", " ").Trim();


            return validFileName;
        }
        public static string MakeValidHttpFileName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("A entrada não pode ser nula ou vazia.");

            // Permitir apenas letras, números, traços, sublinhados e pontos
            string validFileName = Regex.Replace(input, @"[^a-zA-Z0-9\-_\.]", "_");

            // Garantir que o nome do arquivo não termine ou comece com "."
            validFileName = validFileName.Trim('.');

            // Garantir que o nome do arquivo não fique vazio após a sanitização
            if (string.IsNullOrEmpty(validFileName))
            {
                validFileName = "arquivo";
            }

            return validFileName;
        }

    }
}