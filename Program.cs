using System.Linq;

namespace Permutations
{
    internal class Program
    {
        static IList<IList<int>> result = new List<IList<int>>();
        static void Permute(int[] arr, int begin)
        {
            if (begin == arr.Length - 1)
            {
                result.Add(arr.ToArray());
                return;
            };

            for (int i = begin; i < arr.Length; i++)
            {
                Swap(arr, begin, i);
                Permute(arr, begin + 1);
                Swap(arr, begin, i);
            }
        }
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            Permute(nums, 0);
            Console.WriteLine();
        }
        static void Swap(int[] arr, int a, int b)
        {
            if (a == b) return;
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}