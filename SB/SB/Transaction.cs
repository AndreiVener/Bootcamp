using System;

namespace SB
{
    public class Transaction
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
    }
}