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

            int rule3 = 0, rule5 = 0, rule7 = 0, rule11 = 0, rule13 = 0, rule17 = 0;
            
            int maxNumber = 0;
            string input;
            
            Console.Write("Max Number: ");
            input = Console.ReadLine();
            maxNumber = Convert.ToInt32(input);
            
            Console.Write("Type the number to apply the rules:\n" +
                          "Available rules:\n" +
                          "3, 5, 7, 11, 13, 17\n" +
                          "Your rules: ");
            input = Console.ReadLine();
            string[] rulesString = input.Split(' ');

            foreach (var s in rulesString)
            {
                if (s == "3") rule3 = 1;
                if (s == "5") rule5 = 1;
                if (s == "7") rule7 = 1;
                if (s == "11") rule11 = 1;
                if (s == "13") rule13 = 1;
                if (s == "17") rule17 = 1;
            }

            

            for (int number = 1; number <= maxNumber; number++)
            {
                
                var arr = new ArrayList();
                if (number % 11 == 0 && rule11 == 1)
                {
                    if(number % 13 == 0) Console.Write("Fezz");
                    Console.WriteLine("Bong");
                    continue;
                }
                
                if (number % 3 == 0 && rule3 == 1) arr.Add("Fizz"); 
                if (number % 5 == 0 && rule5 == 1) arr.Add("Buzz");
                if (number % 7 == 0 && rule7 == 1) arr.Add("Bang");
                
                if (number % 13 == 0 && rule13 == 1)
                {
                    int foundStringStartingWithB = 0;
                    for (int at = 0; at < arr.Count && foundStringStartingWithB == 0; at++ )
                    {
                        foundStringStartingWithB = insertIfExistsBWord(at, arr);
                    }

                    if (foundStringStartingWithB == 0) arr.Add("Fezz");
                }

                if (number % 17 == 0 && rule17 == 1) arr.Reverse();
                
                print(number,arr);

                
            }
        }
            
    }
}