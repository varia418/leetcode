internal class Program
{
    private static void Main(string[] args)
    {
        string s = "abcba";
        int result = LengthOfLongestSubstring(s);

        Console.WriteLine(result);
        // var temp = s.Skip(1).Take(2).ToArray();
        // System.Console.WriteLine(temp);
    }

    public static int LengthOfLongestSubstring(string s)
    {
        if(string.IsNullOrEmpty(s)) return 0;

        HashSet<char> hSet = new HashSet<char>();
        int max = 0, i = 0, j = 0;
        while(i < s.Length)
        {
            if (!hSet.Contains(s[i]))
            {
                hSet.Add(s[i]);
                i++;
            }
            else 
            {
                max = Math.Max(max, hSet.Count);
                hSet.Remove(s[j]);
                j++;
            }
        }
        max = Math.Max(max, hSet.Count);
        return max;
    }
}