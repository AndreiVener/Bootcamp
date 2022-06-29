using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Xml.Serialization;
using CsvHelper;
using Newtonsoft.Json;
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
            var target = new FileTarget
            {
                FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}"
            };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            logger.Info("Starting program");

            var path = "C:\\Work\\Bootcamp\\SB\\SB\\Transactions2012.xml";
            var absolutePath = "C:\\Work\\Bootcamp\\SB\\SB\\";
            var bank = new Bank();
            var parserFactory = new ParserFactory();

            var parser = parserFactory.CreateParser(path);
            parser.Parse(bank, path);

            while (true)
            {
                string input;
                input = Console.ReadLine();
                var split = input.Split(' ');

                if (split[0] == "exit") return;

                if (split.Length == 3 && split[0] == "Import" && split[1] == "File")
                {
                    Console.WriteLine("Reading...");
                    var newPath = string.Concat(absolutePath, split[2]);
                    bank.deleteRecords();
                    parser = parserFactory.CreateParser(newPath);
                    parser.Parse(bank, newPath);
                }
                else if (split.Length == 3 && split[0] == "Export" && split[1] == "File")
                {
                    Console.WriteLine("Exporting...");
                    var newPath = string.Concat(absolutePath, split[2]);
                    var writer = new StreamWriter(string.Concat(absolutePath, split[2]));

                    var fi = new FileInfo(newPath);

                    if (fi.Extension == ".csv")
                    {
                        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                        csv.WriteRecords(bank.AllTransactions);
                        writer.Close();
                    }
                    else if (fi.Extension == ".json")
                    {
                        var jsonString = JsonConvert.SerializeObject(bank.AllTransactions);
                        writer.WriteLine(jsonString);
                        writer.Close();
                    }
                }
                else if (split.Length == 2 && split[0] == "List" && split[1] == "All")
                {
                    bank.ListAll();
                }
                else if (split.Length >= 2 && split[0] == "List")
                {
                    var name = string.Join(" ", split.Skip(1));
                    bank.List(name);
                }
                else
                {
                    Console.WriteLine("Invalid command! Try again.");
                }

                Console.WriteLine("-----------------------------------");
            }
        }
    }
}