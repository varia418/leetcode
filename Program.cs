internal class Program
{
    private static void Main(string[] args)
    {
        int target = 10;
        int[] position = [6, 8];
        int[] speed = [3, 2];
        int result = CarFleet(target, position, speed);
        Console.WriteLine(result);
    }

    public static int CarFleet(int target, int[] position, int[] speed)
    {
        Array.Sort(position, speed);
        Stack<float> stack = new();
        for (int i = 0; i < position.Length; i++)
        {
            float timeToReachTarget = (float)(target - position[i]) / speed[i];

            while (stack.Any() && timeToReachTarget >= stack.Peek())
            {
                stack.Pop();
            }

            stack.Push(timeToReachTarget);
        }

        return stack.Count;
    }

    // public static int CarFleet(int target, int[] position, int[] speed)
    // {
    //     if (position.Length == 1) return 1;

    //     Dictionary<int, int> dict = new Dictionary<int, int>();
    //     for (int i = 0; i < position.Length; i++)
    //     {
    //         dict[position[i]] = speed[i];
    //     }

    //     dict = dict.OrderBy(entry => entry.Key).ToDictionary();

    //     bool done = false;

    //     while (!done)
    //     {
    //         Dictionary<int, int> updatedDict = new();
    //         for (int i = 0; i < dict.Count - 1; i++)
    //         {
    //             var entry = dict.ElementAt(i);

    //             var nextEntry = dict.ElementAt(i + 1);
    //             float time = (float)(nextEntry.Key - entry.Key) / (entry.Value - nextEntry.Value);

    //             if (time > 0 && entry.Key + time * entry.Value <= target)
    //             {
    //                 updatedDict[nextEntry.Key] = nextEntry.Value;
    //                 if (updatedDict.ContainsKey(entry.Key)) updatedDict.Remove(entry.Key);
    //             }
    //             else
    //             {
    //                 updatedDict[entry.Key] = entry.Value;
    //             }
    //         }

    //         var lastEntry = dict.Last();
    //         if (!updatedDict.ContainsKey(lastEntry.Key))
    //         {
    //             updatedDict[lastEntry.Key] = lastEntry.Value;
    //         }


    //         if (updatedDict.Count == dict.Count)
    //         {
    //             done = true;
    //         }
    //         else
    //         {
    //             dict = updatedDict;
    //             dict = dict.OrderBy(entry => entry.Key).ToDictionary();
    //         }
    //     }

    //     return dict.Count;
    // }

    // public static int CarFleet(int target, int[] position, int[] speed)
    // {
    //     if (position.Length == 1) return 1;

    //     int fleetCount = 0;

    //     Dictionary<int, int> dict = new Dictionary<int, int>();
    //     for (int i = 0; i < position.Length; i++)
    //     {
    //         dict[position[i]] = speed[i];
    //     }

    //     dict = dict.OrderByDescending(entry => entry.Key).ToDictionary();

    //     while (dict.Count > 0)
    //     {
    //         Dictionary<int, int> updatedDict = new();
    //         for (int i = 0; i < dict.Count; i++)
    //         {
    //             var entry = dict.ElementAt(i);

    //             // if (entry.Key > target)
    //             // {
    //             //     fleetCount++;
    //             //     continue;
    //             // }

    //             int consecutiveCarPosition = updatedDict.Count > 0 ? updatedDict.ElementAt(updatedDict.Count - 1).Key : Int32.MaxValue;
    //             int nextPosition = Math.Min(consecutiveCarPosition, entry.Key + entry.Value);

    //             if (nextPosition > target)
    //             {
    //                 fleetCount++;
    //                 continue;
    //             }

    //             updatedDict[nextPosition] = Math.Min(entry.Value, updatedDict.GetValueOrDefault(nextPosition, Int32.MaxValue));
    //         }

    //         dict = updatedDict;
    //     }

    //     return fleetCount;
    // }
}