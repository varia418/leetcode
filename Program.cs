int[] height = new int[] { 1, 3, 2, 5, 25, 24, 5 };

int left = 0, right = height.Length - 1;
int maxArea = 0;

while (left < right)
{
    int area = Math.Min(height[left], height[right]) * (right - left);
    if (area > maxArea)
    {
        maxArea = area;
    }

    if (height[left] <= height[right])
    {
        left++;
    }
    else
    {
        right--;
    }
}

Console.WriteLine(maxArea);