internal class Program
{
    private static void Main(string[] args)
    {
        int[] candidates = [10, 1, 2, 7, 6, 1, 5];
        int target = 8;
        var temp = CombinationSum2(candidates, target);
        Console.WriteLine("Hello, World!");
    }

    private static List<IList<int>> result = new();

    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        DFS(candidates, target, new int[0], 0);
        return result;
    }

    private static void DFS(int[] candidates, int target, int[] prev, int index)
    {
        for (int i = index; i < candidates.Length; i++)
        {
            int sum = prev.Sum() + candidates[i];
            int[] current = prev.Concat(new int[] { candidates[i] }).ToArray();

            if (sum == target)
            {
                result.Add(current);
                return;
            }
            else if (sum < target)
            {

                DFS(candidates, target, current, i + 1);
            }
            else
            {
                return;
            }

            while (i < candidates.Length - 1 && candidates[i + 1] == candidates[i])
            {
                i++;
            }
        }
    }
}