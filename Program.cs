internal class Program
{
    private static void Main(string[] args)
    {
        // char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        // string word = "ABCCED";
        char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'E', 'S'], ['A', 'D', 'E', 'E']];
        string word = "ABCESEEEFS";
        bool result = Exist(board, word);
        Console.WriteLine(result);
    }

    public static bool Exist(char[][] board, string word)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] == word[0])
                {
                    bool exist = SearchWord(board, word, row, col, 0);
                    if (exist) return true;
                }
            }
        }

        return false;
    }

    public static bool SearchWord(char[][] board, string word, int row, int col, int index)
    {
        if (word.Length == index) return true;

        int m = board.Length, n = board[0].Length;
        if (row < 0 || row >= m || col < 0 || col >= n) return false;
        if (board[row][col] != word[index]) return false;

        bool exist = false;
        char temp = board[row][col];
        board[row][col] = ' ';

        exist = exist || SearchWord(board, word, row - 1, col, index + 1);
        exist = exist || SearchWord(board, word, row + 1, col, index + 1);
        exist = exist || SearchWord(board, word, row, col - 1, index + 1);
        exist = exist || SearchWord(board, word, row, col + 1, index + 1);

        if (!exist) board[row][col] = temp;

        return exist;
    }

    // public static bool SearchWord(char[][] board, string word, (int row, int col)[] prev)
    // {
    //     if (word.Length == prev.Length) return true;

    //     var (row, col) = prev.Last();
    //     bool exist = false;

    //     char temp = board[row][col];
    //     board[row][col] = ' ';

    //     if (row > 0 && board[row - 1][col] == word[prev.Length])
    //     {
    //         board[row - 1][col] = ' ';
    //         exist = SearchWord(board, word, prev.Append((row - 1, col)).ToArray());
    //     }

    //     if (row < (board.Length - 1) && board[row + 1][col] == word[prev.Length])
    //     {
    //         exist = exist || SearchWord(board, word, prev.Append((row + 1, col)).ToArray());
    //     }

    //     if (col > 0 && board[row][col - 1] == word[prev.Length])
    //     {
    //         exist = exist || SearchWord(board, word, prev.Append((row, col - 1)).ToArray());
    //     }

    //     if (col < (board[0].Length - 1) && board[row][col + 1] == word[prev.Length])
    //     {
    //         exist = exist || SearchWord(board, word, prev.Append((row, col + 1)).ToArray());
    //     }

    //     if (!exist) board[row][col] = temp;

    //     return exist;
    // }
}