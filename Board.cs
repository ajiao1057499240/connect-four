public class Board
{
    private char[,] grid;
    private int rows = 6;
    private int columns = 7;

    public Board()
    {
        grid = new char[rows, columns];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
                grid[r, c] = ' ';
    }

    public bool DropDisc(int column, char symbol)
    {
        if (column < 0 || column >= columns)
            return false;

        for (int r = rows - 1; r >= 0; r--)
        {
            if (grid[r, column] == ' ')
            {
                grid[r, column] = symbol;
                return true;
            }
        }
        return false;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("    1   2   3   4   5   6   7");
        for (int r = 0; r < rows; r++)
        {
            Console.Write("|");
            for (int c = 0; c < columns; c++)
            {
                if (grid[r, c] == 'X') Console.ForegroundColor = ConsoleColor.Red;
                else if (grid[r, c] == 'O') Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ResetColor();

                Console.Write($" {grid[r, c]} ");
                Console.ResetColor();
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }

    public bool CheckWin(char symbol)
    {
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns - 3; c++)
                if (grid[r, c] == symbol && grid[r, c + 1] == symbol &&
                    grid[r, c + 2] == symbol && grid[r, c + 3] == symbol)
                    return true;

        for (int c = 0; c < columns; c++)
            for (int r = 0; r < rows - 3; r++)
                if (grid[r, c] == symbol && grid[r + 1, c] == symbol &&
                    grid[r + 2, c] == symbol && grid[r + 3, c] == symbol)
                    return true;

        for (int r = 0; r < rows - 3; r++)
            for (int c = 0; c < columns - 3; c++)
                if (grid[r, c] == symbol && grid[r + 1, c + 1] == symbol &&
                    grid[r + 2, c + 2] == symbol && grid[r + 3, c + 3] == symbol)
                    return true;

        for (int r = 3; r < rows; r++)
            for (int c = 0; c < columns - 3; c++)
                if (grid[r, c] == symbol && grid[r - 1, c + 1] == symbol &&
                    grid[r - 2, c + 2] == symbol && grid[r - 3, c + 3] == symbol)
                    return true;

        return false;
    }

    public bool IsFull()
    {
        for (int c = 0; c < columns; c++)
            if (grid[0, c] == ' ')
                return false;
        return true;
    }

    public void Reset()
    {
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
                grid[r, c] = ' ';
    }
}
