internal class Program
{
    private static void Main(string[] args)
    {
        var result = CheckInclusion("ab", "eidbaooo");
        Console.WriteLine(result);
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        if (s2.Length < s1.Length) return false;

        Dictionary<char, int> frequencyMap = new();
        Dictionary<char, int> subStrFrequencyMap = new();
        foreach (char c in s1)
        {
            frequencyMap[c] = frequencyMap.GetValueOrDefault(c, 0) + 1;
        }

        int l = 0;
        int r = l + s1.Length - 1;

        for (int i = l; i < r; i++)
        {
            subStrFrequencyMap[s2[i]] = subStrFrequencyMap.GetValueOrDefault(s2[i], 0) + 1;

        }

        for (; r < s2.Length; r++)
        {
            bool sameCharFrequency = true;
            var currentChar = s2[r];
            subStrFrequencyMap[currentChar] = subStrFrequencyMap.GetValueOrDefault(currentChar, 0) + 1;

            foreach (KeyValuePair<char, int> entry in frequencyMap)
            {
                if (entry.Value != subStrFrequencyMap.GetValueOrDefault(entry.Key, 0))
                {
                    sameCharFrequency = false;
                    break;
                }
            }

            if (sameCharFrequency)
            {
                return true;
            }

            subStrFrequencyMap[s2[l]]--;
            l++;
        }

        return false;
    }
}