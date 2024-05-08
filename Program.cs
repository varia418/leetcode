internal class Program
{
    private static void Main(string[] args)
    {
        FindRelativeRanks([5, 4, 3, 2, 1]);
        Console.WriteLine("Hello, World!");
    }

    public static string[] FindRelativeRanks(int[] score)
    {
        Dictionary<int, string> dict = new();

        for (int i = 0; i < score.Length; i++)
        {
            dict[score[i]] = i.ToString();
        }

        int index = 0;
        dict = dict.OrderByDescending(i => i.Key).Select(pair =>
        {
            index++;
            switch (index)
            {
                case 1:
                    return new KeyValuePair<int, string>(pair.Key, "Gold Medal");
                case 2:
                    return new KeyValuePair<int, string>(pair.Key, "Silver Medal");
                case 3:
                    return new KeyValuePair<int, string>(pair.Key, "Bronze Medal");
                default:
                    return new KeyValuePair<int, string>(pair.Key, $"{index}");
            }
        }).ToDictionary();

        string[] answer = score.Select(s => dict[s]).ToArray();

        return answer;
    }
}