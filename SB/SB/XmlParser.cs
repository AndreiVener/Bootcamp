using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SB
{
    public class XmlParser : Parser
    {
        public void Parse(Bank bank, string xmlPath)
        {
            TransactionList transactionList = null;

            var serializer = new XmlSerializer(typeof(TransactionList));
            var reader = new StreamReader(xmlPath);
            transactionList = (TransactionList)serializer.Deserialize(reader);
            reader.Close();

            foreach (var st in transactionList.SupportTransactions)
            {
                var t = new Transaction()
                {
                    From = st.Party.From,
                    To = st.Party.To,
                    Narrative = st.Description,
                    Date = st.Date,
                    Amount = st.Value
                };
                bank.AddTransaction(t);
            }
        }
    }
}