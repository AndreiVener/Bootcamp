using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SB
{
    [Serializable()]
    [XmlRoot(ElementName = "XMLROOT")]
    public class TransactionList
    {
      
        [XmlArray("TransactionList")]
        [XmlArrayItem("SupportTransaction", typeof(SupportTransaction))]
        public SupportTransaction[] SupportTransactions { get; set; }
    }
}