internal class Program
{
    private static void Main(string[] args)
    {
        var result = Partition("aab");
        Console.WriteLine("Hello, World!");
    }

    private static List<IList<string>> result = new();

    public static IList<IList<string>> Partition(string s)
    {
        Backtrack(s, 0, new List<string>());
        return result;
    }

    private static void Backtrack(string s, int start, List<string> path)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(path));
            return;
        }

        for (int end = start; end < s.Length; end++)
        {
            if (IsPalindrome(s, start, end))
            {
                path.Add(s.Substring(start, end - start + 1));
                Backtrack(s, end + 1, path);
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    private static bool IsPalindrome(string s, int low, int high)
    {
        while (low < high)
        {
            if (s[low++] != s[high--]) return false;
        }

        return true;
    }
}