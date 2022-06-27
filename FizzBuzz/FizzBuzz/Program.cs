using System;

namespace FizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int k = 1; k <= 100; k++)
            {
                if (k % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (k % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }else if (k % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }else
                {
                    Console.WriteLine(k);
                }
                
            }
        }
    }
}