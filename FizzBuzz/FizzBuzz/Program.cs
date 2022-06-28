using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FizzBuzz;


namespace FizzBuzz
{
    internal class Program
    {
        public static int insertIfExistsWord(int at, ArrayList arr, string specifiedChar, string word)
        {
            int exists = 0;
            var t = (string)arr[at];
            if (t.Substring(0, 1) == specifiedChar)
            {
                arr.Insert(at, word);
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

        public static void applyRules(int number, List<Rule> rules)
        {
            var arr = new ArrayList();
            bool onlyRule = false;

            foreach (Rule rule in rules)
            {
                if (number % rule.number == 0)
                {
                    if (rule.onlyThis == true)
                    {
                        Console.WriteLine(rule.word);
                        onlyRule = true;
                        break;
                    }
                    if (rule.priorityBeforeChar != " ")
                    {
                        int foundStringSpecifiedChar= 0;
                        for (int at = 0; at < arr.Count && foundStringSpecifiedChar == 0; at++)
                        {
                            foundStringSpecifiedChar = insertIfExistsWord(at, arr,rule.priorityBeforeChar,rule.word);
                        }
                        
                        if (foundStringSpecifiedChar == 0) arr.Add(rule.word);
                    }
                    else
                    {
                        arr.Add(rule.word);
                    }
                }
            }
            if(onlyRule == false) print(number, arr);
        }
        public static void Main(string[] args)
        {
            List<Rule> rules = new List<Rule>();
            rules.Add(new Rule(3, "Fizz"));
            rules.Add(new Rule(5, "Buzz"));
            rules.Add(new Rule(7, "Bang"));
            rules.Add(new Rule(11,"BENG",onlyThis:true));
            //rules.Add(new Rule(13,"BONG",priorityBeforeChar:"B"));

            int maxNumber = 0;
            string input;

            Console.Write("Max Number: ");
            input = Console.ReadLine();
            maxNumber = Convert.ToInt32(input);

            for (int number = 1; number <= maxNumber; number++) applyRules(number, rules);
            
        }

    }
}
    