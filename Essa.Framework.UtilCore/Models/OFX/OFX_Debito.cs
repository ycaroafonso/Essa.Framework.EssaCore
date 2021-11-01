using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Essa.Framework.Util.Models.OFX
{
    public partial class OFX
    {
    }
    public sealed class BANKACCTFROM
    {
        public int BANKID { get; set; }
        public string BRANCHID { get; set; }
        public string ACCTID { get; set; }
        public string ACCTTYPE { get; set; }
    }



    [XmlType("STMTTRN")]
    public sealed class STMTTRN
    {
        public string TRNTYPE { get; set; }

        [XmlIgnore]
        public DateTime DTPOSTED { get; set; }
        [XmlElement("DTPOSTED")]
        public string _DTPOSTED { get { return DTPOSTED.ToString("yyyyMMdd"); } set { DTPOSTED = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture); } }



        public decimal TRNAMT { get; set; }
        public string FITID { get; set; }
        public string MEMO { get; set; }

        [XmlElement("CURRENCY")]
        public List<CURRENCY> CURRENCY { get; set; }
        public string REFNUM { get; set; }
        public string CHECKNUM { get; set; }
    }

}
