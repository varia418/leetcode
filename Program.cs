internal class Program
{
    private static void Main(string[] args)
    {
        int result = CharacterReplacement("AABABCA", 1);
        Console.WriteLine(result);
    }

    public static int CharacterReplacement(string s, int k)
    {
        int maxLength = 0;
        int l = 0;
        int lettersToChange = 0;
        int maxFrequency = 0;
        Dictionary<char, int> frequencyMap = new();

        for (int r = 0; r < s.Length; r++)
        {
            char currentChar = s[r];
            frequencyMap[currentChar] = frequencyMap.GetValueOrDefault(currentChar) + 1;
            maxFrequency = Math.Max(maxFrequency, frequencyMap[currentChar]);

            lettersToChange = r - l + 1 - maxFrequency;

            if (lettersToChange > k)
            {
                frequencyMap[s[l]]--;
                l++;
            }

            maxLength = Math.Max(maxLength, r - l + 1);
        }

        return maxLength;
    }
}