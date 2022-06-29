using System;
using System.Collections.Generic;

namespace SB
{
    public class Bank
    {
        public IDictionary<string, Person> PeopleDict = new Dictionary<string, Person>();
        public List<Transaction> AllTransactions = new List<Transaction>();

        public void AddTransaction(Transaction t)
        {
            AllTransactions.Add(t);

            if (!PeopleDict.ContainsKey(t.From)) PeopleDict.Add(t.From, new Person(t.From));
            if (!PeopleDict.ContainsKey(t.To)) PeopleDict.Add(t.To, new Person(t.To));

            PeopleDict[t.From].Owe -= t.Amount;
            PeopleDict[t.To].Owed += t.Amount;

            PeopleDict[t.From].Transactions.Add(t);
            PeopleDict[t.To].Transactions.Add(t);
        }

        public void ListAll()
        {
            //logger.Info("List All command is running");


            foreach (var personEntity in PeopleDict)
                Console.WriteLine(personEntity.Key + " Owe: \t" + personEntity.Value.Owe + " \tOwed: " +
                                  personEntity.Value.Owed);
            //logger.Info("LIST ALL command done!");
        }

        public void List(string name)
        {
            //logger.Info("List {0} -> command is running",name);
            if (!PeopleDict.ContainsKey(name)) return;
            foreach (var t in PeopleDict[name].Transactions) Console.WriteLine(t.Date + "\t" + t.Narrative);
            //logger.Info("List {0} -> command is done",name);
        }

        public void deleteRecords()
        {
            PeopleDict = new Dictionary<string, Person>();
            AllTransactions = new List<Transaction>();
        }
    }
}