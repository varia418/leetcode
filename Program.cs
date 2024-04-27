internal class Program
{
    private static void Main(string[] args)
    {
        int[] nums = [9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6];
        int result = LongestConsecutive(nums);
        Console.WriteLine(result);
    }

    public static int LongestConsecutive(int[] nums)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int longestConsecutive = 0;
        foreach (int num in nums)
        {
            dict[num] = 1;
        }

        dict = dict.OrderBy(entry => entry.Key).ToDictionary();

        int count = 0;
        foreach (var entry in dict)
        {
            if (count == 0 || dict.GetValueOrDefault(entry.Key - 1, 0) == 1)
            {
                count++;
                longestConsecutive = Math.Max(longestConsecutive, count);
            }
            else
            {
                count = 1;
            }
        }

        return longestConsecutive;
    }
}