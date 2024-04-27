static bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length) return false;

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

    if (compareResult.Count > 0) return false;

    return true;
}

string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
//List<List<string>> answer = new List<List<string>>();

//for (int i = 0; i < strs.Length; i++)
//{
//    bool didAdd = false;
//    foreach (List<string> anagrams in answer)
//    {
//        if (IsAnagram(anagrams[0], strs[i]))
//        {
//            anagrams.Add(strs[i]);
//            didAdd = true; 
//            break;
//        }
//    }

//    if (!didAdd)
//    {
//        answer.Add(new List<string> { strs[i] });
//    }
//}

//foreach (List<string> strList in answer)
//{
//    Console.Write("[ ");
//    foreach (string str in strList)
//    {
//        Console.Write(str);
//        Console.Write(" ");
//    }
//    Console.Write(" ]\n");
//}

var temp = strs.GroupBy(str => new string(str.OrderBy(c => c).ToArray()));
var temp2 = temp.Select(g => 
{ 
    return g.ToList() as IList<string>; 
});
var temp3 = temp2.ToList();

return 0;