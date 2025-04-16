using System;
using System.Diagnostics;

public class GameController
{
    private Board board;
    private Player player1;
    private Player player2;

    public GameController()
    {
        board = new Board();
    }

    public void Start()
    {
        Console.Write("Enter name for Player 1 (X): ");
        string name1 = Console.ReadLine();
        Console.Write("Enter name for Player 2 (O): ");
        string name2 = Console.ReadLine();

        player1 = new HumanPlayer(name1, 'X');
        player2 = new HumanPlayer(name2, 'O');

        bool playAgain = true;

        while (playAgain)
        {
            Player current = player1;
            board.Reset();

            while (true)
            {
                board.Display();
                Console.WriteLine($"{current.Name} ({current.Symbol}), you have 10 seconds to choose a column (1-7): ");

                int column = -1;
                Stopwatch timer = new Stopwatch();
                timer.Start();

                while (timer.Elapsed.TotalSeconds < 10)
                {
                    if (Console.KeyAvailable)
                    {
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out column) && column >= 1 && column <= 7)
                        {
                            column -= 1;
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid input. Enter number 1–7: ");
                        }
                    }
                }

                timer.Stop();

                if (column == -1)
                {
                    Console.WriteLine("\n⏱ Time's up! You missed your turn.");
                    current = current == player1 ? player2 : player1;
                    continue;
                }

                if (!board.DropDisc(column, current.Symbol))
                {
                    Console.WriteLine("Column full! Try again.");
                    continue;
                }

                if (board.CheckWin(current.Symbol))
                {
                    board.Display();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{current.Name} wins! 🎉");
                    Console.ResetColor();
                    break;
                }

                if (board.IsFull())
                {
                    board.Display();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nIt's a draw!");
                    Console.ResetColor();
                    break;
                }

                current = current == player1 ? player2 : player1;
            }

            Console.Write("\nWould you like to play again? (y/n): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "y" || response == "yes";
        }

        Console.WriteLine("Thanks for playing Connect Four! 👋");
    }
}
