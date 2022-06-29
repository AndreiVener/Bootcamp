using System;
using System.Xml.Serialization;

namespace SB
{
    [Serializable()]
    public class SupportTransaction
    {
        [XmlAttribute("Date")] public string Date { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Value")] public double Value { get; set; }

        [XmlElement(ElementName = "Parties")] public Parties Party { get; set; }
    }
}