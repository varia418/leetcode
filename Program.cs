namespace Combination_Sum
{
    internal class Program
    {
        static IList<IList<int>> result = new List<IList<int>>();
        static void Main(string[] args)
        {
            int[] candidates = { 8, 7, 4, 3 };
            int target = 11;
            DFS(candidates, target, Array.Empty<int>(), 0);
            Console.WriteLine();
        }
        private static void DFS(int[] candidates, int target, int[] previousArr, int index)
        {
            if (index > candidates.Length) return;

            for (int i = index; i < candidates.Length; i++)
            {
                int[] subset = new int[previousArr.Length + 1];
                previousArr.CopyTo(subset, 0);
                subset[previousArr.Length] = candidates[i];
                int sum = subset.Aggregate((a, b) => a + b);
                if (sum == target)
                {
                    result.Add(subset);
                }
                else if (sum < target)
                {
                    DFS(candidates, target, subset, i);
                }
            }
        }
    }
}