using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    internal class Program
    {

        public static int insertIfExistsBWord(int at,ArrayList arr)
        {
            int exists = 0;
            var t = (string)arr[at];
            if (t.Substring(0, 1) == "B")
            {
                arr.Insert(at, "Fezz");
                exists = 1;
            }
            return exists;
        }
        public static void print(int number, ArrayList arr)
        {
            if (arr.Count != 0)
            {
                foreach (var s in arr)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(number);
            }
        }
        public static void Main(string[] args)
        {
          
            for (int number = 1; number <= 100; number++)
            {
                
                var arr = new ArrayList();
                if (number % 11 == 0)
                {
                    if(number % 13 == 0) Console.Write("Fezz");
                    Console.WriteLine("Bong");
                    continue;
                }
                
                if (number % 3 == 0) arr.Add("Fizz"); 
                if (number % 5 == 0) arr.Add("Buzz");
                if (number % 7 == 0) arr.Add("Bang");
                
                if (number % 13 == 0)
                {
                    int foundStringStartingWithB = 0;
                    for (int at = 0; at < arr.Count && foundStringStartingWithB == 0; at++ )
                    {
                        foundStringStartingWithB = insertIfExistsBWord(at, arr);
                    }

                    if (foundStringStartingWithB == 0) arr.Add("Fezz");
                }

                if (number % 17 == 0) arr.Reverse();
                
                print(number,arr);

                
            }
        }
            
    }
}