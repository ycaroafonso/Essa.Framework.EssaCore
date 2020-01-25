namespace Essa.Framework.Util.Models.OFX
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;


    //public class OFXUtil
    //{
    //    public string _valor;
    //    public DateTime Value { get { return DateTime.ParseExact(_valor, "yyyyMMdd", CultureInfo.InvariantCulture); } }

    //    public static implicit operator OFXUtil(string valor)
    //    {
    //        return new OFXUtil { _valor = valor };
    //    }

    //    public static implicit operator DateTime(OFXUtil valor)
    //    {
    //        return valor.Value;
    //    }
    //}


    public partial class OFX
    {

    }




    [Serializable()]
    public class STMTRS
    {
        public string CURDEF { get; set; }


        /// <summary>
        /// Conta Corrente
        /// </summary>
        public BANKACCTFROM BANKACCTFROM { get; set; }

        /// <summary>
        /// Cartão de crédito
        /// </summary>
        public CCACCTFROM CCACCTFROM { get; set; }

        public BANKTRANLIST BANKTRANLIST { get; set; }
    }

    public sealed class LEDGERBAL
    {
        public decimal BALAMT { get; set; }


        [XmlIgnore]
        public DateTime DTASOF { get; set; }

        [XmlElement("DTASOF")]
        public string _DTASOF { get { return DTASOF.ToShortDateString(); } set { DTASOF = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture); } }

    }

    [Serializable()]
    public sealed class BANKTRANLIST
    {
        public BANKTRANLIST()
        {
            STMTTRN = new List<STMTTRN>();
        }


        [XmlIgnore]
        public DateTime DTSTART { get; set; }
        [XmlIgnore]
        public DateTime DTEND { get; set; }



        [XmlElement("DTSTART")]
        public string _DTSTART { get { return DTSTART.ToShortDateString(); } set { DTSTART = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture); } }

        [XmlElement("DTEND")]
        public string _DTEND { get { return DTEND.ToShortDateString(); } set { DTEND = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture); } }



        public int? ANOMES { get; set; }


        [XmlElement("STMTTRN")]
        public List<STMTTRN> STMTTRN { get; set; }


    }


    [XmlType("CURRENCY")]
    public class CURRENCY
    {
        public decimal CURRATE { get; set; }
        public string CURSYM { get; set; }
    }
}


