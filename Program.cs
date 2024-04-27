internal class Program
{
    private static void Main(string[] args)
    {
        GenerateParenthesis(4);
    }
    private static HashSet<string> result = new();

    public static IList<string> GenerateParenthesis(int n)
    {
        if (n == 1)
        {
            return new string[] { "()" };
        }

        DFS(n - 1, "()");
        return result.ToList();
    }

    private static void DFS(int m, string prev)
    {
        // if (m < 1) return;

        if (m == 1)
        {
            for (int i = 0; i < prev.Length; i++)
            {
                result.Add(prev.Substring(0, i) + "()" + prev.Substring(i));
            }

            return;
        }

        for (int i = 0; i < prev.Length; i++)
        {
            DFS(m - 1, prev.Substring(0, i) + "()" + prev.Substring(i));
        }
    }
}