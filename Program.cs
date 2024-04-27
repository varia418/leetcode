namespace Subsets
{
    internal class Program
    {
        static void FindSubset(IList<IList<int>> result, int[] previousSubset, int[] nums, int index, int subsetLength)
        {
            if (index >= nums.Length) return;
            for (; index < nums.Length; index += 1)
            {
                int[] subset = new int[subsetLength];
                previousSubset.CopyTo(subset, 0);
                subset[subsetLength - 1] = nums[index];
                result.Add(subset);
                FindSubset(result, subset, nums, index + 1, subsetLength + 1);
            }
        }
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new int[0]);
            int subsetLength = 1;
            FindSubset(result, (int[])result[0], nums, 0, subsetLength);
            return;

        }
    }
}