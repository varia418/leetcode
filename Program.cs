int[][] matrix = new int[][] {
    new int[] {1, 3, 5, 7 },
    new int[] {10, 11, 16, 20},
    new int[] {23, 30, 34, 60 }
};
int target = 13;

int n = matrix[0].Length;
int m = matrix.Length;
int top = 0, bottom = m - 1;
while (top <= bottom)
{
    int verticalMid = top + (bottom - top) / 2;
    if (target > matrix[verticalMid][n - 1])
    {
        top = verticalMid + 1;
    }
    else if (target < matrix[verticalMid][0])
    {
        bottom = verticalMid - 1;
    }
    else
    {
        int left = 0, right = n - 1;
        while (left <= right)
        {
            int horizontalMid = left + (right - left) / 2;

            if (target > matrix[verticalMid][horizontalMid])
            {
                left = horizontalMid + 1;
            }
            else if (target < matrix[verticalMid][horizontalMid])
            {
                right = horizontalMid - 1;
            }
            else
            {
                Console.WriteLine(true);
                return;
            }
        }
        break;
    }
}

Console.WriteLine(false);
return;