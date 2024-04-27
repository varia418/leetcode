string s = "anagram";
string t = "nagaram";

if (s.Length != t.Length) Console.WriteLine("false");

Dictionary<char, int> sDict = new Dictionary<char, int>();
Dictionary<char, int> tDict = new Dictionary<char, int>();
for (int i = 0; i < s.Length; i++)
{
    if (!sDict.ContainsKey(s[i]))
    {
        sDict.Add(s[i], 1);
    }
    else
    {
        sDict[s[i]]++;
    }

    if (!tDict.ContainsKey(t[i]))
    {
        tDict.Add(t[i], 1);
    }
    else
    {
        tDict[t[i]]++;
    }
}
int charCount = 0;
Dictionary<char, int> compareResult = sDict.Where(entry => 
{
    tDict.TryGetValue(entry.Key, out charCount);
    return charCount != entry.Value;
}).ToDictionary(entry => entry.Key, entry => entry.Value);

if (compareResult.Count > 0)
{
    Console.WriteLine("false");
}
else
{
Console.WriteLine("true");
}
