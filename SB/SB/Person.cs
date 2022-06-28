using System.Runtime.InteropServices;

namespace SB
{
    public class Person
    {
        public double Owe { get; set; }
        public double Owed{ get; set; }
        public string Name{ get; set; }

        public Person(string name)
        {
            Name = name;
            Owe = 0;
            Owed = 0;
        }

    }
}