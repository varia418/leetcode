internal class Program
{
    private static void Main(string[] args)
    {
        int[] nums = [1, 3, 4, 2, 2];
        int result = FindDuplicate(nums);
        Console.WriteLine(result);
    }

    public static int FindDuplicate(int[] nums)
    {
        int fast = nums[0];
        int slow = nums[0];

        do
        {
            fast = nums[nums[fast]];
            slow = nums[slow];
        }
        while (slow != fast);

        int secondSlow = nums[0];

        while (secondSlow != slow)
        {
            slow = nums[slow];
            secondSlow = nums[secondSlow];
        }

        return slow;
    }
}