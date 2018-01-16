using System.Xml.Serialization;

namespace ExchangeRates.Models
{
    [XmlRoot("web_dis_rates")]
    public class CurrencyRates
    {
        [XmlElement("timestamp")]
        public string Timestamp { get; set; }

        [XmlElement("row")]
        public Row[] Row { get; set; }
    }

    public class Row
    {
        [XmlElement("swift_code")]
        public string SwiftCode { get; set; }

        [XmlElement("swift_name")]
        public string SwiftName { get; set; }

        [XmlElement("multiply")]
        public string Multiply { get; set; }

        [XmlElement("buy_cash")]
        public string BuyCash { get; set; }

        [XmlElement("sell_cash")]
        public string SellCash { get; set; }

        [XmlElement("base_swift")]
        public string BaseSwift { get; set; }

        [XmlElement("CurrencyGuide")]
        public CurrencyGuide CurrencyGuide { get; set; }
    }

    public class CurrencyGuide
    {
        [XmlAttribute(AttributeName = "BaseSwift")]
        public string BaseSwift { get; set; }

        [XmlAttribute(AttributeName = "Swift")]
        public string Swift { get; set; }

        [XmlAttribute(AttributeName = "Amount")]
        public string Amount { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}