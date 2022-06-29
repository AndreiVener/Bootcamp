using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SB
{
    public class Person
    {
        public double Owe { get; set; }
        public double Owed { get; set; }
        public string Name { get; set; }
        public List<Transaction> Transactions;

        public Person(string name)
        {
            Transactions = new List<Transaction>();
            Name = name;
            Owe = 0;
            Owed = 0;
        }
    }
}