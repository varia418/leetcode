using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var result = LetterCombinations("23");
        Console.WriteLine("Hello, World!");
    }

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();
        var builder = new StringBuilder();

        Dictionary<char, char[]> dict = new Dictionary<char, char[]>();
        dict.Add('2', ['a', 'b', 'c']);
        dict.Add('3', ['d', 'e', 'f']);
        dict.Add('4', ['g', 'h', 'i']);
        dict.Add('5', ['j', 'k', 'l']);
        dict.Add('6', ['m', 'n', 'o']);
        dict.Add('7', ['p', 'q', 'r', 's']);
        dict.Add('8', ['t', 'u', 'v']);
        dict.Add('9', ['w', 'x', 'y', 'z']);

        List<string> answer = dict[digits[0]].Select(c => c.ToString()).ToList();
        if (digits.Length == 1) return answer;

        foreach (char digit in digits.Skip(1))
        {
            answer = answer.SelectMany(x =>
                dict[digit].SelectMany(y =>
                {
                    builder.Clear();
                    builder.Append(x);
                    builder.Append(y);
                    return new[] { builder.ToString() };
                })
            ).ToList();
        }

        return answer;
    }
}