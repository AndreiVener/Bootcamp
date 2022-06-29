using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using NLog;

namespace SB
{
    public class CsvParser : Parser
    {
        public void Parse(Bank bank, string csvPath)
        {
            var reader = new StreamReader(csvPath);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            //logger.Info("Started reading CSV");
            csvReader.Read();
            csvReader.ReadHeader();
            var indexOfCsvRow = -1;

            while (csvReader.Read())
            {
                indexOfCsvRow++;

                try
                {
                    var transaction = new Transaction
                    {
                        From = csvReader.GetField("From"),
                        To = csvReader.GetField("To"),
                        Date = csvReader.GetField("Date"),
                        Narrative = csvReader.GetField("Narrative"),
                        Amount = csvReader.GetField<double>("Amount")
                    };
                    bank.AddTransaction(transaction);
                }
                catch (Exception ex)
                {
                    //logger.Error(ex, "Error while reading from CSV at row {0}",indexOfCsvRow);
                }
            }
            //logger.Info("Finished reading the CSV");
        }
    }
}