using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        public static string print(int number, ArrayList arr)
        {
            StringBuilder sb = new StringBuilder();
            if (arr.Count != 0)
            {
                foreach (var s in arr) sb.Append(s);
            }
            else
            {
                sb.Append(Convert.ToString(number));
            }

            return sb.ToString();
        }

        public static string applyRules(int number, List<Rule> rules)
        {
            var arr = new ArrayList();

            foreach (Rule rule in rules)
            {
                if (number % rule.number == 0)
                {
                    if (rule.onlyThis)
                    {
                        return rule.word;
                    }

                    if (rule.priorityBeforeChar != " ")
                    {
                        int foundStringSpecifiedChar = 0;
                        for (int at = 0; at < arr.Count && foundStringSpecifiedChar == 0; at++)
                        {
                            foundStringSpecifiedChar = insertIfExistsWord(at, arr, rule.priorityBeforeChar, rule.word);
                        }

                        if (foundStringSpecifiedChar == 0) arr.Add(rule.word);
                    }
                    else
                    {
                        arr.Add(rule.word);
                    }
                }
            }

            return print(number, arr);
        }

        public static void Main(string[] args)
        {
            // List<Rule> rules = new List<Rule>();
            // rules.Add(new Rule(3, "Fizz"));
            // rules.Add(new Rule(5, "Buzz"));
            // rules.Add(new Rule(7, "Bang"));
            // rules.Add(new Rule(11, "BENG", onlyThis: true));
            // //rules.Add(new Rule(13,"BONG",priorityBeforeChar:"B"));
            //
            // int maxNumber = 0;
            // string input;
            //
            // Console.Write("Max Number: ");
            // input = Console.ReadLine();
            //
            // maxNumber = Convert.ToInt32(input);
            // string[] res = new string[maxNumber];
            // int idx = 0;
            //
            // for (int number = 1; number <= maxNumber; number++)
            // {
            //     res[idx] = applyRules(number, rules);
            //     idx++;
            // }
            //
            // var fizz = new FizzBuzzer(res);
            // foreach (var val in fizz)
            // {
            //     Console.WriteLine(val);
            // }

            var res = Enumerable.Range(1, 100).Select(x => x % 15 == 0 ? "FizzBuzz" : 
                (x % 5 == 0 ? "Buzz" : (x % 3 == 0 ? "Fizz" : Convert.ToString(x))));
            
            foreach (var s in res)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class FizzBuzzer : IEnumerable
    {
        public string[] res;

        public FizzBuzzer(string[] list)
        {
            res = list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public FizzBuzzerEnum GetEnumerator()
        {
            return new FizzBuzzerEnum(res);
        }
    }

    public class FizzBuzzerEnum : IEnumerator
    {
        public string[] res;
        private int currentIndex = -1;

        public FizzBuzzerEnum(string[] list)
        {
            res = list;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < res.Length);
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public string Current
        {
            get { return res[currentIndex]; }
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}