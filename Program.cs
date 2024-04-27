internal class Program
{
    private static void Main(string[] args)
    {
        string s = "]";
        Dictionary<char, char> parentheses = new Dictionary<char, char>();
        parentheses['('] = ')';
        parentheses['['] = ']';
        parentheses['{'] = '}';
        parentheses[')'] = '(';
        parentheses[']'] = '[';
        parentheses['}'] = '{';
        char[] openBrackets = { '(', '[', '{' };
        char[] closeBrackets = { ')', ']', '}' };
        Stack<char> foundBrackets = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (openBrackets.Contains(s[i]))
            {
                foundBrackets.Push(s[i]);
            }
            else if (closeBrackets.Contains(s[i]))
            {
                if (foundBrackets.Count == 0)
                {
                    Console.WriteLine(false);
                    return;
                }
                if (foundBrackets.Pop() != parentheses[s[i]])
                {
                    Console.WriteLine(false);
                    return;
                }
            }
        }

        if(foundBrackets.Count != 0)
        {
            Console.WriteLine(false);
            return;
        }
     
        Console.WriteLine(true);
        return;
    }
}