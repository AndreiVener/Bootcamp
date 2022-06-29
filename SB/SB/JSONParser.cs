using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SB
{
    public class JSONParser : Parser
    {
        public void Parse(Bank bank, string jsonPath)
        {
            List<TransactionJsonMap> transactionsJson = null;
            var input = File.ReadAllText(jsonPath);

            try
            {
                transactionsJson = JsonConvert.DeserializeObject<List<TransactionJsonMap>>(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
            }

            if (transactionsJson == null) return;

            foreach (var tJson in transactionsJson)
            {
                var t = new Transaction()
                {
                    Amount = tJson.Amount,
                    From = tJson.FromAccount,
                    To = tJson.ToAccount,
                    Date = tJson.Date,
                    Narrative = tJson.Narrative
                };
                bank.AddTransaction(t);
            }
        }
    }
}