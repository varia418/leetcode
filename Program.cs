int[] nums = new int[] { 1, 2, 3, 4 };

//int product = nums.Aggregate(1, (acc, x) => acc * x);
//List<int> result = new List<int>();
//for (int i = 0; i < nums.Length; i++)
//{
//    if (nums[i] == 0)
//    {
//        result.Add(nums.Aggregate(1, (acc, x) =>
//        {
//            if (x != nums[i]) return acc * x;
//            return acc;
//        }));
//    }
//    else
//    {
//        result.Add(product / nums[i]);
//    }
//}

var numOfZeroes = nums.Where(num => num == 0).Count();
if (numOfZeroes >= 2)
{
    var result = nums.Select(num => 0).ToArray();
    return 0;
}
else
{
    int product = nums.Aggregate(1, (acc, x) => acc * x);
    List<int> result = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0)
        {
            result.Add(nums.Aggregate(1, (acc, x) =>
            {
                if (x != nums[i]) return acc * x;
                return acc;
            }));
        }
        else
        {
            result.Add(product / nums[i]);
        }
    }
    return 0;
}