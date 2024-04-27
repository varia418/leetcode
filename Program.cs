using System.ComponentModel.Design;

namespace Search_in_Rotated_Sorted_Array
{
    internal class Program
    {
        static int Main(string[] args)
        {
            int[] nums = { 4, 5, 6, 7, 8, 1, 2, 3 };
            int target = 8;
            int n = nums.Length;
            int left = 0, right = n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    Console.WriteLine(mid);
                    return mid;
                }

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            Console.WriteLine(-1);
            return -1;
        }
    }
}