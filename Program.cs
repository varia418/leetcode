internal class Program
{
    private static void Main(string[] args)
    {
        int[] nums = [1, 2, 1];
        int[] result = GetConcatenation(nums);
        Console.WriteLine("Hello, World!");
    }

    public static int[] GetConcatenation(int[] nums)
    {
        return nums.Concat(nums).ToArray();
    }
}