namespace Essa.Framework.UtilCore.Models.OFX
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;
    using Util;


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


    public class OFX
    {

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



        [XmlElement("STMTTRN")]
        public List<STMTTRN> STMTTRN { get; set; }


    }

    [XmlType("STMTTRN")]
    public sealed class STMTTRN
    {
        public string TRNTYPE { get; set; }

        [XmlIgnore]
        public DateTime DTPOSTED { get; set; }
        [XmlElement("DTPOSTED")]
        public string _DTPOSTED { get { return DTPOSTED.ToShortDateString(); } set { DTPOSTED = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture); } }



        public decimal TRNAMT { get; set; }
        public string FITID { get; set; }
        public string MEMO { get; set; }

        [XmlElement("CURRENCY")]
        public List<CURRENCY> CURRENCY { get; set; }
        public string REFNUM { get; set; }
        public string CHECKNUM { get; set; }
    }


    [XmlType("CURRENCY")]
    public class CURRENCY
    {
        public decimal CURRATE { get; set; }
        public string CURSYM { get; set; }
    }
}


