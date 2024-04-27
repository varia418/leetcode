int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

int n = nums.Length;
Array.Sort(nums);
List<List<int>> result = new List<List<int>>();
int i = 0;
while (i < n - 2)
{
    int target = - nums[i];
    int left = i + 1, right = n - 1;
    while (left < right)
    {
        int sum = nums[left] + nums[right];
        if (sum < target)
        {
            left++;
        }
        else if (sum > target)
        {
            right--;
        }
        else
        {
            List<int> oneSolution = new List<int>() { nums[i], nums[left], nums[right] };
            result.Add(oneSolution);

            while (left < right && nums[left] == oneSolution[1])
            {
                left++;
            }
            while (left < right && nums[right] == oneSolution[2])
            {
                right--;
            }
        }
    }
    int currentStartNumber = nums[i];
    while (i < n - 2 && nums[i] == currentStartNumber)
    {
        i++;
    }
}

foreach (List<int> triplet in result)
{
    Console.WriteLine(string.Join(", ", triplet));
}