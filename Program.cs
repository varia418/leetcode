namespace Find_Minimum_in_Rotated_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 2 };
            int n = nums.Length;
            int left = 0, right = n - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            Console.WriteLine(nums[left]);
        }
    }
}