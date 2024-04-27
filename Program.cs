int[] numbers = new int[] { 3, 24, 50, 79, 88, 150, 345 };
int target = 200;

for (int i = 0; i < numbers.Length - 1; i++)
{
    int complementNumber = target - numbers[i];
    int leftIndex = i + 1, rightIndex = numbers.Length - 1;
    int j = rightIndex;
    
    while (leftIndex != rightIndex)
    {
        if (complementNumber < numbers[j])
        {
            rightIndex = j - 1;
        }
        else if (complementNumber > numbers[j])
        {
            leftIndex = j + 1;
        }
        else
        {
            Console.WriteLine("i = {0:D}, j = {1:D}", i + 1, j + 1);
            return;
        }

        if (leftIndex > rightIndex) break;

        j = (rightIndex + leftIndex) / 2;
    }
    if (leftIndex == rightIndex)
    {
        if (numbers[i] + numbers[leftIndex] == target)
        {
            Console.WriteLine("i = {0:D}, j = {1:D}", i + 1, leftIndex + 1);
            return;
        }
    }
    
}
Console.WriteLine("No result!");
return;