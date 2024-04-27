char[][] board = new char[][] { 
    new char[]{'5','3','.','.','7','.','.','.','.'},
    new char[]{'6','.','.','1','9','5','.','.','.'},
    new char[]{'.','9','8','.','.','.','.','6','.'},
    new char[]{'8','.','.','.','6','.','.','.','3'},
    new char[]{'4','.','.','8','.','3','.','.','1'},
    new char[]{'7','.','.','.','2','.','.','.','6'},
    new char[]{'.','6','.','.','.','.','2','8','.'},
    new char[]{'.','.','.','4','1','9','.','.','5'},
    new char[]{'.','.','.','.','8','.','.','7','9'}
};

HashSet<char> firstGrid = new HashSet<char>();
HashSet<char> secondGrid = new HashSet<char>();
HashSet<char> thirdGrid = new HashSet<char>();

for (int i = 0; i < 9; i++)
{
    HashSet<char> rowWithoutDot = new HashSet<char>();
    HashSet<char> columnWithoutDot = new HashSet<char>();

    if (i % 3 == 0)
    {
        firstGrid.Clear();
        secondGrid.Clear();
        thirdGrid.Clear();
    }

    for (int j = 0; j < 9; j++)
    {
        if (board[i][j] != '.')
        {
            if (rowWithoutDot.Contains(board[i][j]))
            {
                Console.WriteLine("false");
                return;
            }
            rowWithoutDot.Add(board[i][j]);

            if (j < 3)
            {
                if (firstGrid.Contains(board[i][j]))
                {
                    Console.WriteLine("false");
                    return;
                }
                firstGrid.Add(board[i][j]);
            }
            else if (j < 6)
            {
                if (secondGrid.Contains(board[i][j]))
                {
                    Console.WriteLine("false");
                    return;
                }
                secondGrid.Add(board[i][j]);
            }
            else if (j < 9)
            {
                if (thirdGrid.Contains(board[i][j]))
                {
                    Console.WriteLine("false");
                    return;
                }
                thirdGrid.Add(board[i][j]);
            }
        }
        
        if (board[j][i] != '.')
        {
            if (columnWithoutDot.Contains(board[j][i]))
            {
                Console.WriteLine("false");
                return;
            }
            columnWithoutDot.Add(board[j][i]);
        }

        
    }
}

Console.WriteLine("true");