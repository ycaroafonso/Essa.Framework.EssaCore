using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essa.Framework.Web.Extensions
{
    public static class UtilExtensions
    {
        public static List<SelectListItem> ToSelectList<T>(this T[] lista)
        {
            return new SelectList(lista).ToList();
        }
        public static List<SelectListItem> ToSelectList<T>(this List<T> lista)
        {
            return new SelectList(lista).ToList();
        }

        public static List<SelectListItem> ToSelectList(this IDictionary lista)
        {
            return new SelectList(lista, "Key", "Value").ToList();
        }

        public static List<SelectListItem> ToSelectList(this IDictionary lista, object valorSelecionado)
        {
            return new SelectList(lista, "Key", "Value", valorSelecionado).ToList();
        }


        public static List<SelectListItem> ToSelectList<T>(this T enumerable, Func<T, object> valor, Func<T, object> texto)
        {
            return ToSelectList(new List<T> { enumerable }, valor, texto, null, null, null);
        }
        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> valor, Func<T, object> texto)
        {
            return ToSelectList(enumerable, valor, texto, "SELECIONE…", null, null);
        }
        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> valor, Func<T, object> texto, object valorSelecionado)
        {
            return ToSelectList(enumerable, valor, texto, "SELECIONE…", null, valorSelecionado);
        }



        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> valor, Func<T, object> texto
            , string nomePrimeiroCampo, string valorPrimeiroCampo, object valorSelecionado = null)
        {
            var list = enumerable.Select(x => new SelectListItem
            {
                Value = valor.Invoke(x).ToString(),
                Text = texto.Invoke(x).ToString(),
            });

            if (nomePrimeiroCampo != null)
            {
                var x = list.ToList();
                x.Insert(0, new SelectListItem { Value = valorPrimeiroCampo, Text = nomePrimeiroCampo });
                list = x;
            }

            return new SelectList(list, "Value", "Text", valorSelecionado).ToList();
        }

        public static DateTime StrToDateTime(this String valor)
        {
            if (valor.IndexOf("/") == -1 && valor.IndexOf("-") == -1)
            {
                return Convert.ToDateTime(valor.Substring(0, 2) + "/" + valor.Substring(2, 2) + "/" + valor.Substring(4));
            }
            else if (valor.IndexOf("-") != -1)
            {
                return new DateTime(valor.Substring(0, 4).StrToInt32(), valor.Substring(5, 2).StrToInt32(), valor.Substring(8, 2).StrToInt32());
            }
            else
                return Convert.ToDateTime(valor);
        }

        public static int StrToInt32(this String valor)
        {
            if (String.IsNullOrWhiteSpace(valor))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(valor);
            }
        }


        public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static async Task<string> GetConteudoArquivoAsync(this IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(memoryStream, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        public static byte[] GetBytes(this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }



    }
}
