using System;
using System.Xml.Serialization;

namespace SB
{
    [Serializable()]
    public class Parties
    {
        [XmlElement("From")] public string From { get; set; }

        [XmlElement("To")] public string To { get; set; }
    }
}