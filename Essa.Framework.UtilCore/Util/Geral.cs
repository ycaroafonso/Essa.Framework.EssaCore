namespace Essa.Framework.UtilCore
{
    using Essa.Framework.UtilCore.Extensions;
    using Essa.Framework.UtilCore.Models.OFX;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;


    public static class Geral
    {
        public static Dictionary<bool, string> SimNaoBooleano()
        {
            return new Dictionary<bool, string>
            {
                {true,"Sim" },
                {false,"Não" },
            };
        }


        public static string[] Meses()
        {
            return new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        }

        public static Dictionary<int, string> MesesComNumero()
        {
            return Meses().Select((item, index) => new { index = index + 1, item }).ToDictionary(c => c.index, d => d.item);
        }

        /// <summary>
        /// Lista de anos até o ano atual
        /// </summary>
        /// <param name="primeiro"></param>
        /// <returns></returns>
        public static IEnumerable<int> Anos(int primeiro)
        {
            for (int ano = primeiro; ano <= DateTime.Today.Year; ano++)
            {
                yield return ano;
            }
        }

        public static IEnumerable<int> Anos(int primeiro, int ate)
        {
            for (int i = primeiro; i <= ate; i++)
            {
                yield return i;
            }
        }


        public static Dictionary<string, string> SimNao()
        {
            return new Dictionary<string, string>
            {
                { "S", "Sim" },
                { "N", "Não" }
            };
        }



        public static bool IsReleaseBuild()
        {
#if DEBUG
            return false;
#else
    return true;
#endif
        }


        public static BANKTRANLIST LerOFX(string xmlstr)
        {
            xmlstr = xmlstr.Substring(xmlstr.IndexOf("<OFX>"));

            XmlDocument xml = new XmlDocument();


            try
            {
                xml.LoadXml(xmlstr.ToString());
            }
            catch (Exception ex)
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in xmlstr.Split(new[] { '\n' }))
                {
                    str.Append(item);

                    var rg = System.Text.RegularExpressions.Regex.Match(item, @"<([^>]*)>([^<]*)([^\n\r]*)").Groups;

                    if (rg[1].Value != "" && rg[2].Value != "" && rg[3].Value == "")
                        str.Append("</" + rg[1].Value + ">");
                    else
                        str.AppendLine("");
                }

                xml.LoadXml(str.ToString());
            }

            var transactions = xml
                .GetElementsByTagName("BANKTRANLIST");

            var serializer = new XmlSerializer(typeof(BANKTRANLIST), new XmlRootAttribute("BANKTRANLIST"));
            var trans = (BANKTRANLIST)serializer.Deserialize(new XmlNodeReader(transactions[0]));

            return trans;
        }

    }
}
