public class HumanPlayer : Player
{
    public HumanPlayer(string name, char symbol) : base(name, symbol) { }

    public override int GetMove(Board board)
    {
        int column;
        Console.Write($"{Name} ({Symbol}), choose column (1-7): ");
        while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 7)
        {
            Console.Write("Invalid input. Enter a number from 1 to 7: ");
        }
        return column - 1;
    }
}