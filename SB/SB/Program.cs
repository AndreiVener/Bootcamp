using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;

namespace SB

{
    
    internal class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        
        public static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            logger.Info("Starting program");   
            var pathToCvs = "C:\\Work\\Bootcamp\\SB\\SB\\DodgyTransactions2015.csv";

            
            
            bool running = true;
            while (running)
            {
                string input;
                input = Console.ReadLine();
                string[] split = input.Split(' ');
                if (split[0] == "exit")
                {
                    running = false;
                }
                else if (split.Length == 2 && split[0] == "List" && split[1] == "All")
                {
                    ListAll(pathToCvs);

                }else if (split.Length == 3 && split[0] == "List")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(split[1] + " " + split[2]);
                    string name = sb.ToString();
                    List(pathToCvs,name);
                }else{
                    Console.WriteLine("Invalid command! Try again.");
                }            
                Console.WriteLine("-----------------------------------");

            }
            
            
           
        }

        private static List<Transaction> getTransactions(string pathToCvs)
        {
            var reader = new StreamReader(pathToCvs);
            var csvReader = new CsvReader(reader,CultureInfo.InvariantCulture);
            
            logger.Info("Started reading CSV");
            csvReader.Read();
            csvReader.ReadHeader();
            int indexOfCsvRow = -1;
            List<Transaction> transactions = new List<Transaction>();
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
                    transactions.Add(transaction);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error while reading from CSV at row {0}",indexOfCsvRow);
                }
            }
            logger.Info("Finished reading the CSV");
            return transactions;
        }
        private static void ListAll(string path)
        {
            logger.Info("List All command is running");
            List<Transaction> transactions = new List<Transaction>();
            transactions = getTransactions(path);
            
            IDictionary<string, Person> PersonDict = new Dictionary<string, Person>();

            foreach (var t in transactions)
            {
                if(!PersonDict.ContainsKey(t.From)) PersonDict.Add(t.From, new Person(t.From));    
                if(!PersonDict.ContainsKey(t.To)) PersonDict.Add(t.To, new Person(t.To));
                PersonDict[t.From].Owe -= t.Amount;
                PersonDict[t.To].Owed += t.Amount;
                // Console.WriteLine(p.From + "\t\t" + p.To +"\t\t"+ p.Amount);
                
            }
            
            foreach (var personEntity in PersonDict)
            {
                Console.WriteLine(personEntity.Key + " Owe: \t" + personEntity.Value.Owe + " \tOwed: " + personEntity.Value.Owed);
            }
            logger.Info("LIST ALL command done!");
        }

        private static void List(string path, string name)
        {
            logger.Info("List {0} -> command is running",name);
            List<Transaction> transactions = new List<Transaction>();
            transactions = getTransactions(path);
            
            foreach (var t in transactions)
            {
                if (t.From == name || t.To == name)
                {
                    Console.WriteLine(t.Date + "\t " + t.Narrative);
                }
            }
            logger.Info("List {0} -> command is done",name);

        }
    }
}