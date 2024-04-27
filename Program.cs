int[] piles = new int[] { 805306368, 805306368, 805306368 };
int h = 1000000000;

int low = 1, high = piles.Max();
int minHours = Int32.MaxValue;

while (low <= high)
{
    int mid = low + (high - low) / 2;
    long currentHours = piles.Aggregate(0, (long a, int b) =>
         {
            return a + (int)Math.Ceiling((double)b / mid);
         });

    if (currentHours > h)
    {
        low = mid + 1;
    }
    else if (currentHours <= h)
    {
        high = mid - 1;
        minHours = Math.Min(minHours, mid);
    }
}

Console.WriteLine(minHours);