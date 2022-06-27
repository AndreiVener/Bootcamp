using System;
using System.Text;

namespace FizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
          
            for (int number = 1; number <= 100; number++)
            {
                int stringFlag = 0;
                StringBuilder sb = new StringBuilder();
                if (number % 3 == 0)
                {
                    stringFlag = 1;
                    sb.Append("Fizz");
                }
                if (number % 5 == 0)
                {
                    stringFlag = 1;
                    sb.Append("Buzz");
                }

                if (stringFlag == 1)
                {
                    Console.WriteLine(sb.ToString());
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
            
    }
}