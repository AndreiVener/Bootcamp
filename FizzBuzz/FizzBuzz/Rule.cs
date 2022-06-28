namespace FizzBuzz
{
    public class Rule
    {
        public int number;
        public string priorityBeforeChar;
        public string word;
        public bool onlyThis;
        public Rule(int number, string word,bool onlyThis = false, string priorityBeforeChar = " ")
        {
            this.number = number;
            this.word = word;
            this.priorityBeforeChar = priorityBeforeChar;
            this.onlyThis = onlyThis;
        }
    }
}