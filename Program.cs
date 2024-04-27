internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = [73, 74, 75, 71, 69, 72, 76, 73];
        var result = DailyTemperatures(input);
        Console.WriteLine(result);
    }

    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Stack<int> stack = new();
        stack.Push(0);

        for (int i = 1; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                result[index] = i - index;
            }

            stack.Push(i);
        }

        return result;
    }

    // public static int[] DailyTemperatures(int[] temperatures)
    // {
    //     int[] result = new int[temperatures.Length];
    //     Stack<int> stack = new();
    //     List<int> indices = new();

    //     stack.Push(temperatures[0]);
    //     indices.Add(0);
    //     int index;

    //     for (int i = 1; i < temperatures.Length; i++)
    //     {
    //         while (stack.Count > 0 && temperatures[i] > stack.Peek())
    //         {
    //             stack.Pop();
    //             index = indices[indices.Count - 1];
    //             result[index] = i - index;
    //             indices.RemoveAt(indices.Count - 1);
    //         }

    //         stack.Push(temperatures[i]);
    //         indices.Add(i);
    //     }

    //     return result;
    // }

    // public static int[] DailyTemperatures(int[] temperatures)
    // {
    //     int[] result = new int[temperatures.Length];
    //     Dictionary<int, int> dict = new();
    //     dict.Add(0, temperatures[0]);

    //     for (int i = 1; i < temperatures.Length; i++)
    //     {
    //         foreach (var entry in dict)
    //         {
    //             if (temperatures[i] > entry.Value)
    //             {
    //                 result[entry.Key] = i - entry.Key;
    //                 dict.Remove(entry.Key);
    //             }
    //         }
    //         dict.Add(i, temperatures[i]);
    //     }

    //     return result;
    // }
}