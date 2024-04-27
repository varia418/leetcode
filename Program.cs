using System.Text.RegularExpressions;

string s = "A man, a plan, a canal: Panama";
string processedString = Regex.Replace(s.ToLower(), @"[^a-zA-Z0-9]", "");
int i = 0, j = processedString.Length - 1;
while (i <= j)
{
    if (processedString[i] != processedString[j])
    {
        Console.WriteLine(false);
        return;
    }
    i++;
    j--;
}

Console.WriteLine(true);
return;