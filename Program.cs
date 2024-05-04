internal class Program
{
    private static void Main(string[] args)
    {
        string word = "abcd";
        char ch = 'z';
        Console.WriteLine(ReversePrefix(word, ch));
    }

    public static string ReversePrefix(string word, char ch)
    {
        string result = string.Empty;
        int i = 0;
        for (; i < word.Length; i++)
        {
            if (word[i] != ch)
            {
                result = word[i] + result;
            }
            else
            {
                break;
            }
        }

        if (i == word.Length) return word;

        result = ch + result + word.Substring(i + 1);

        return result;
    }
}