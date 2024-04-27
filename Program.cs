internal class Program
{
    private static void Main(string[] args)
    {
        int[] prices = [7,1,5,3,6,4];
        int result = MaxProfit(prices);
        System.Console.WriteLine(result);
    }

    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
                if (prices[j] <= prices[i])
                {
                    i++;
                }
            }
        }
        return maxProfit;
    }
}