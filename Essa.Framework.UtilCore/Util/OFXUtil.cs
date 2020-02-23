namespace Essa.Framework.Util.Util
{
    using Essa.Framework.Util.Models.OFX;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;


    public class OFXUtil
    {
        public int? Banco { get; set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public string NumeroCartao { get; private set; }


        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public int? AnoMes { get; private set; } = null;


        public List<STMTTRN> Transacoes { get; set; }

        public TipoContaEnum TipoConta { get; set; }
        public enum TipoContaEnum
        {
            Corrente,
            Credito
        }




        XmlDocument _xml;
        public OFXUtil(string xmlstr)
        {
            _xml = new XmlDocument();

            try
            {
                xmlstr = xmlstr.Substring(xmlstr.IndexOf("<OFX>"));
                _xml.LoadXml(xmlstr.ToString());
            }
            catch (Exception)
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

                _xml.LoadXml(str.ToString());
            }


            MontarAgenciaContaTransacoes();
        }






        public void MontarAgenciaContaTransacoes()
        {
            var STMTRS = _xml
                .GetElementsByTagName("STMTRS");

            STMTRS trans;

            if (STMTRS.Count == 0)
            {
                TipoConta = TipoContaEnum.Credito;

                STMTRS = _xml.GetElementsByTagName("CCSTMTRS");

                trans = (STMTRS)(new XmlSerializer(typeof(STMTRS), new XmlRootAttribute("CCSTMTRS")))
                    .Deserialize(new XmlNodeReader(STMTRS[0]));

                NumeroCartao = trans.CCACCTFROM.ACCTID;

            }
            else
            {
                TipoConta = TipoContaEnum.Corrente;

                trans = (STMTRS)(new XmlSerializer(typeof(STMTRS), new XmlRootAttribute("STMTRS")))
                    .Deserialize(new XmlNodeReader(STMTRS[0]));

                Agencia = trans.BANKACCTFROM?.BRANCHID;
                Conta = trans.BANKACCTFROM?.ACCTID;
                Banco = trans.BANKACCTFROM?.BANKID;
            }

            DataInicio = trans.BANKTRANLIST.DTSTART;
            DataFim = trans.BANKTRANLIST.DTEND;
            AnoMes = trans.BANKTRANLIST.ANOMES;

            Transacoes = trans.BANKTRANLIST.STMTTRN;
        }

    }
}
